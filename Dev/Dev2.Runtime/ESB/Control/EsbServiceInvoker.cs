/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


#region Change Log

//  Author:         Sameer Chunilall
//  Date:           2010-01-24
//  Log No:         9299
//  Description:    The data layer of the Dynamic Service Engine
//                  This is where all actions get executed.

#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Communication;
using Dev2.DataList.Contract;
using Dev2.Diagnostics.Debug;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Interfaces;
using Dev2.Runtime.ESB.Control;
using Dev2.Runtime.ESB.Execution;
using Dev2.Workspaces;
using Warewolf.Resource.Errors;

// ReSharper disable CheckNamespace
namespace Dev2.Runtime.ESB
// ReSharper restore CheckNamespace
{

    #region Invokes Endpoint and returns responses to the Caller


    public class EsbServiceInvoker : IEsbServiceInvoker, IDisposable
    {
        private readonly IServiceLocator _serviceLocator;

        #region Fields
        private readonly IEsbChannel _esbChannel;

        private readonly IWorkspace _workspace;

        private readonly EsbExecuteRequest _request;

        #endregion

       private readonly ConcurrentDictionary<Guid, ServiceAction> _cache = new ConcurrentDictionary<Guid, ServiceAction>();

        // 2012.10.17 - 5782: TWR - Changed to work off the workspace host and made read only

        #region Constructors

        public EsbServiceInvoker(IEsbChannel esbChannel,IWorkspace workspace, EsbExecuteRequest request = null)
            :this(new ServiceLocator())
        {
            _esbChannel = esbChannel;
          

            // 2012.10.17 - 5782: TWR - Added workspace parameter
            _workspace = workspace;

            _request = request;
        }

        private EsbServiceInvoker(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        #endregion

        #region Travis New Methods

        /// <summary>
        /// Invokes the specified service as per the dataObject against theHost
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Can only execute workflows from web browser</exception>
        public Guid Invoke(IDSFDataObject dataObject, out ErrorResultTO errors)
        {
            var result = GlobalConstants.NullDataListID;
            var time = new Stopwatch();
            time.Start();
            errors = new ErrorResultTO();
            const int Update = 0;
            if(dataObject.Environment.HasErrors())
            {
                errors.AddError(dataObject.Environment.FetchErrors());
                DispatchDebugErrors(errors, dataObject, StateType.Before);
            }
            errors.ClearErrors();
            try
            {
                var serviceId = dataObject.ResourceID;

                var serviceName = dataObject.ServiceName;
                if(serviceId == Guid.Empty && string.IsNullOrEmpty(serviceName))
                {
                    errors.AddError(Resources.DynamicServiceError_ServiceNotSpecified);
                }
                else
                {

                    try
                    {
                        Dev2Logger.Debug("Finding service");
                        var theService = serviceId == Guid.Empty ? _serviceLocator.FindService(serviceName, _workspace.ID) : _serviceLocator.FindService(serviceId, _workspace.ID);

                        if(theService == null)
                        {
                            theService = _serviceLocator.FindService(serviceName, GlobalConstants.ServerWorkspaceID);
                            if (theService == null)
                            {
                                if (dataObject.IsServiceTestExecution)
                                {
                                    var testResult = new TestRunResult
                                    {
                                        Message = "Resource has been deleted",
                                        Result = RunResult.TestResourceDeleted,
                                        TestName = dataObject.TestName,
                                        DebugForTest = new List<IDebugState>()
                                    };
                                    var ser = new Dev2JsonSerializer();
                                    _request.ExecuteResult = ser.SerializeToBuilder(testResult);
                                }

                                errors.AddError(string.Format(ErrorResource.ServiceNotFound, serviceName));
                            }

                        }
                        else if(theService.Actions.Count <= 1)
                        {
                            #region Execute ESB container

                            var theStart = theService.Actions.FirstOrDefault();
                            if(theStart != null && theStart.ActionType != Common.Interfaces.Core.DynamicServices.enActionType.InvokeManagementDynamicService && theStart.ActionType != Common.Interfaces.Core.DynamicServices.enActionType.Workflow && dataObject.IsFromWebServer)
                            {
                                throw new Exception(ErrorResource.CanOnlyExecuteWorkflowsFromWebBrowser);
                            }
                            Dev2Logger.Debug("Mapping Action Dependencies");
                            MapServiceActionDependencies(theStart, _serviceLocator);

                            if(theStart != null)
                            {
                                theStart.DataListSpecification = theService.DataListSpecification;
                                Dev2Logger.Debug("Getting container");
                                if (dataObject.IsServiceTestExecution)
                                {
                                    theStart.ActionType =Common.Interfaces.Core.DynamicServices.enActionType.TestExecution;
                                }
                                var container = GenerateContainer(theStart, dataObject, _workspace);
                                ErrorResultTO invokeErrors;
                                result = container.Execute(out invokeErrors, Update);
                                errors.MergeErrors(invokeErrors);
                            }
                            #endregion
                        }
                        else
                        {
                            errors.AddError(string.Format(ErrorResource.MalformedService, serviceId));
                        }
                    }
                    catch(Exception e)
                    {
                        errors.AddError(e.Message);
                    }
                    finally
                    {
                        if (dataObject.Environment.HasErrors())
                        {
                            var errorString = dataObject.Environment.FetchErrors();
                            var executionErrors = ErrorResultTO.MakeErrorResultFromDataListString(errorString);
                            errors.MergeErrors(executionErrors);
                        }

                        dataObject.Environment.AddError(errors.MakeDataListReady());

                        if(errors.HasErrors())
                        {
                            Dev2Logger.Error(errors.MakeDisplayReady());
                        }
                    }
                }
            }
            finally
            {
                time.Stop();
                ServerStats.IncrementTotalRequests();
                ServerStats.IncrementTotalTime(time.ElapsedMilliseconds);
                // BUG 9706 - 2013.06.22 - TWR : added
                DispatchDebugErrors(errors, dataObject, StateType.End);
            }
            return result;
        }

        /// <summary>
        /// Generates the invoke container.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="serviceId">The service unique identifier.</param>
        /// <param name="isLocalInvoke">if set to <c>true</c> [is local invoke].</param>
        /// <param name="masterDataListId">The master data list unique identifier.</param>
        /// <returns></returns>
        public IEsbExecutionContainer GenerateInvokeContainer(IDSFDataObject dataObject, Guid serviceId, bool isLocalInvoke, Guid masterDataListId = default(Guid))
        {
            if(isLocalInvoke)
            {
                ServiceAction sa;
                if(_cache.ContainsKey(dataObject.ResourceID))
                {
                    sa = _cache[dataObject.ResourceID];
  
                    return GenerateContainer(sa, dataObject, _workspace);
                }


                var theService = _serviceLocator.FindService(serviceId, _workspace.ID);
                if(theService != null && theService.Actions.Any())
                {
                    sa = theService.Actions.FirstOrDefault();
                    MapServiceActionDependencies(sa, _serviceLocator);
                    _cache.TryAdd(dataObject.ResourceID, sa);
                    return GenerateContainer(sa, dataObject, _workspace);
                }

                return null;
            }
            return GenerateContainer(new ServiceAction { ActionType = Common.Interfaces.Core.DynamicServices.enActionType.RemoteService }, dataObject, null);
        }


        /// <summary>
        /// Generates the invoke container.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="isLocalInvoke">if set to <c>true</c> [is local invoke].</param>
        /// <param name="masterDataListId">The master data list unique identifier.</param>
        /// <returns></returns>
        public IEsbExecutionContainer GenerateInvokeContainer(IDSFDataObject dataObject, String serviceName, bool isLocalInvoke, Guid masterDataListId = default(Guid))
        {
            if(isLocalInvoke)
            {

                if (_cache.ContainsKey(dataObject.ResourceID))
                {
                    ServiceAction sa = _cache[dataObject.ResourceID];

                    return GenerateContainer(sa, dataObject, _workspace);
                }
                    // ReSharper disable RedundantIfElseBlock
                else
                    // ReSharper restore RedundantIfElseBlock
                {
                    var resourceId = dataObject.ResourceID;
                    DynamicService theService = GetService(serviceName, resourceId, _serviceLocator);
                    IEsbExecutionContainer executionContainer = null;


                    if (theService != null && theService.Actions.Any())
                    {
                        var sa = theService.Actions.FirstOrDefault();
                        MapServiceActionDependencies(sa, _serviceLocator);
                        _cache.TryAdd(dataObject.ResourceID, sa);
                        executionContainer = GenerateContainer(sa, dataObject, _workspace);
                    }

                    return executionContainer; 
                }

            }
            return GenerateContainer(new ServiceAction { ActionType = Common.Interfaces.Core.DynamicServices.enActionType.RemoteService }, dataObject, null);
        }

        private DynamicService GetService(string serviceName, Guid resourceId, IServiceLocator sl)
        {
            try
            {
                Dev2Logger.Debug($"Getting DynamicService: {serviceName}");
                if(resourceId == Guid.Empty)
                {
                    return sl.FindService(serviceName, _workspace.ID) ?? sl.FindService(serviceName, GlobalConstants.ServerWorkspaceID); //Check the workspace is it something we are working on if not use the server version
                }
                return sl.FindService(resourceId, _workspace.ID) ?? sl.FindService(resourceId, GlobalConstants.ServerWorkspaceID); //Check the workspace is it something we are working on if not use the server version
            }catch(Exception)
            {
                //Internal services
                return null;
            }
        }

        private IEsbExecutionContainer GenerateContainer(ServiceAction serviceAction, IDSFDataObject dataObj, IWorkspace theWorkspace)
        {
            // set the ID for later use ;)
            dataObj.WorkspaceID = _workspace.ID;

            IEsbExecutionContainer result = null;

            switch(serviceAction.ActionType)
            {
                case Common.Interfaces.Core.DynamicServices.enActionType.TestExecution:
                    result = new ServiceTestExecutionContainer(serviceAction,dataObj,theWorkspace,_esbChannel, _request);
                    break;
                case Common.Interfaces.Core.DynamicServices.enActionType.InvokeManagementDynamicService:
                    result = new InternalServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel, _request);
                    break;
                case Common.Interfaces.Core.DynamicServices.enActionType.InvokeWebService:
                    result = new WebServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                    break;

                case Common.Interfaces.Core.DynamicServices.enActionType.Workflow:
                    result = new PerfmonExecutionContainer( new WfExecutionContainer(serviceAction, dataObj, theWorkspace, _esbChannel));
                    break;
                case Common.Interfaces.Core.DynamicServices.enActionType.RemoteService:
                    result = new RemoteWorkflowExecutionContainer(serviceAction, dataObj, null, _esbChannel);
                    break;
            }

            return result;
        }

        private void MapServiceActionDependencies(ServiceAction serviceAction, IServiceLocator serviceLocator)
        {

            serviceAction.Service = GetService(serviceAction.ServiceName, serviceAction.ServiceID, serviceLocator);
            if(!string.IsNullOrWhiteSpace(serviceAction.SourceName))
            {
                serviceAction.Source = serviceLocator.FindSourceByName(serviceAction.SourceName, _workspace.ID);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {

        }

        #endregion

        #region DispatchDebugErrors

        // BUG 9706 - 2013.06.22 - TWR : refactored
        private void DispatchDebugErrors(ErrorResultTO errors, IDSFDataObject dataObject, StateType stateType)
        {
            if(errors.HasErrors() && dataObject.IsDebugMode())
            {
                Guid parentInstanceId;
                Guid.TryParse(dataObject.ParentInstanceID, out parentInstanceId);

                var debugState = new DebugState
                {
                    ID = dataObject.DataListID,
                    ParentID = parentInstanceId,
                    WorkspaceID = dataObject.WorkspaceID,
                    StateType = stateType,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    ActivityType = ActivityType.Workflow,
                    DisplayName = dataObject.ServiceName,
                    IsSimulation = dataObject.IsOnDemandSimulation,
                    ServerID = dataObject.ServerID,
                    OriginatingResourceID = dataObject.ResourceID,
                    OriginalInstanceID = dataObject.OriginalInstanceID,
                    SessionID = dataObject.DebugSessionID,
                    EnvironmentID = dataObject.EnvironmentID,
                    ClientID = dataObject.ClientID,
                    Server = string.Empty,
                    Version = string.Empty,
                    Name = GetType().Name,
                    HasError = errors.HasErrors(),
                    ErrorMessage = errors.MakeDisplayReady()
                };

                DebugDispatcher.Instance.Write(debugState, dataObject.IsServiceTestExecution, dataObject.TestName, dataObject.RemoteInvoke, dataObject.RemoteInvokerID);
            }
        }

        #endregion

    }

    #endregion
}
