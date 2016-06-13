﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using Dev2.CodedUI.Tests;
using Dev2.CodedUI.Tests.UIMaps.DocManagerUIMapClasses;

namespace Dev2.Studio.UI.Tests.UIMaps.EmailSourceWizardUIMapClasses
{
    using System.CodeDom.Compiler;
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

    public partial class EmailSourceWizardUIMap : WizardsUIMap
    {

        public void ClickTestConnection()
        {
            Keyboard.SendKeys("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
        }

        public void ClickSaveEmailSource()
        {
            Keyboard.SendKeys("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
        }

        /// <summary>
        /// Click Cancel
        /// </summary>
        public void ClickCancel()
        {
            #region Variable Declarations
            var uIItemImage = new DocManagerUIMap().UIBusinessDesignStudioWindow.GetChildren()[0].GetChildren()[0];
            #endregion

            //Click Cancel
            Mouse.Click(uIItemImage, new Point(638, 459));
        }

        public void ClickSave()
        {
            var uIItemImage = StudioWindow.GetChildren()[0].GetChildren()[2];
            Mouse.Click(uIItemImage, new Point(525, 425));
        }
    }

    [GeneratedCode("Coded UITest Builder", "11.0.60315.1")]
    public class UIStartPageCustom : WpfCustom
    {

        public UIStartPageCustom(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.ContentPane";
            this.SearchProperties["AutomationId"] = "splurt";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public WpfImage UIItemImage
        {
            get
            {
                if((this.mUIItemImage == null))
                {
                    this.mUIItemImage = new WpfImage(this);
                    #region Search Criteria
                    this.mUIItemImage.WindowTitles.Add(TestBase.GetStudioWindowName());
                    #endregion
                }
                return this.mUIItemImage;
            }
        }
        #endregion

        #region Fields
        private WpfImage mUIItemImage;
        #endregion
    }
}