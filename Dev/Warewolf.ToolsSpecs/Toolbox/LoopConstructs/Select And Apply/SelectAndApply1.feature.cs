﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.ToolsSpecs.Toolbox.LoopConstructs.SelectAndApply
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SelectAndApplyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SelectAndApply.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SelectAndApply", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SelectAndApply")))
            {
                Warewolf.ToolsSpecs.Toolbox.LoopConstructs.SelectAndApply.SelectAndApplyFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute a selectAndApply over a tool using a recordset with 3 rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void ExecuteASelectAndApplyOverAToolUsingARecordsetWith3Rows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute a selectAndApply over a tool using a recordset with 3 rows", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table1.AddRow(new string[] {
                        "[[rs().field]]",
                        "1"});
            table1.AddRow(new string[] {
                        "[[rs().field]]",
                        "2"});
            table1.AddRow(new string[] {
                        "[[rs().field]]",
                        "3"});
#line 9
 testRunner.Given("There is a recordset in the datalist with this shape", ((string)(null)), table1, "Given ");
#line 14
 testRunner.And("Alias is \"[[bob]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Datasource is \"[[rs(*).field]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("the underlying dropped activity is \"SelectTestTool\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("the selectAndApply executes 3 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "[[rs(*).field]]"});
            table2.AddRow(new string[] {
                        "As = [[bob]]"});
#line 20
 testRunner.And("the debug inputs as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute a selectAndApply over a tool using a complexobject with 3 properties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void ExecuteASelectAndApplyOverAToolUsingAComplexobjectWith3Properties()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute a selectAndApply over a tool using a complexobject with 3 properties", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table3.AddRow(new string[] {
                        "[[Person().name]]",
                        "Micky"});
            table3.AddRow(new string[] {
                        "[[Person().name]]",
                        "John"});
            table3.AddRow(new string[] {
                        "[[Person().name]]",
                        "Scott"});
#line 27
 testRunner.Given("There is a complexobject in the datalist with this shape", ((string)(null)), table3, "Given ");
#line 32
 testRunner.And("Alias is \"[[bob]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("Datasource is \"[[Person(*).name]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("the underlying dropped activity is \"SelectTestTool\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the selectAndApply executes 3 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "[[Person(*).name]]"});
            table4.AddRow(new string[] {
                        "As = [[bob]]"});
#line 38
 testRunner.And("the debug inputs as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Number Format tool with complext object deeper level")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void NumberFormatToolWithComplextObjectDeeperLevel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Number Format tool with complext object deeper level", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table5.AddRow(new string[] {
                        "[[Person.Score().Avg]]",
                        "0.3"});
            table5.AddRow(new string[] {
                        "[[Person.Score().Avg]]",
                        "0.45"});
            table5.AddRow(new string[] {
                        "[[Person.Score().Avg]]",
                        "0.12"});
#line 45
 testRunner.Given("There is a complexobject in the datalist with this shape", ((string)(null)), table5, "Given ");
#line 50
 testRunner.And("Alias is \"[[Avg]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("Datasource is \"[[Person.Score(*).Avg]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Rounding",
                        "Rounding Value",
                        "Decimals to show",
                        "Result"});
            table6.AddRow(new string[] {
                        "[[Avg]]",
                        "Up",
                        "2",
                        "3",
                        "[[Avg]]"});
#line 52
 testRunner.And("I use a Number Format tool configured as", ((string)(null)), table6, "And ");
#line 55
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("\"[[Person.Score(1).Avg]]\" has a value of \"0.300\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("\"[[Person.Score(2).Avg]]\" has a value of \"0.450\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("\"[[Person.Score(3).Avg]]\" has a value of \"0.120\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Number Format tool with complext object multi array")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void NumberFormatToolWithComplextObjectMultiArray()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Number Format tool with complext object multi array", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table7.AddRow(new string[] {
                        "[[Person().Score().Avg]]",
                        "0.3"});
            table7.AddRow(new string[] {
                        "[[Person().Score().Avg]]",
                        "0.45"});
            table7.AddRow(new string[] {
                        "[[Person().Score().Avg]]",
                        "0.12"});
#line 64
 testRunner.Given("There is a complexobject in the datalist with this shape", ((string)(null)), table7, "Given ");
#line 69
 testRunner.And("Alias is \"[[Avg]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("Datasource is \"[[Person(*).Score(*).Avg]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Rounding",
                        "Rounding Value",
                        "Decimals to show",
                        "Result"});
            table8.AddRow(new string[] {
                        "[[Avg]]",
                        "Up",
                        "2",
                        "3",
                        "[[Avg]]"});
#line 71
 testRunner.And("I use a Number Format tool configured as", ((string)(null)), table8, "And ");
#line 74
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.Then("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
 testRunner.And("\"[[Person(1).Score(1).Avg]]\" has a value of \"0.300\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("\"[[Person(2).Score(2).Avg]]\" has a value of \"0.450\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("\"[[Person(3).Score(3).Avg]]\" has a value of \"0.120\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Number Format tool with complext object")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void NumberFormatToolWithComplextObject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Number Format tool with complext object", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table9.AddRow(new string[] {
                        "[[Person().Level]]",
                        "0.3"});
            table9.AddRow(new string[] {
                        "[[Person().Level]]",
                        "0.45"});
            table9.AddRow(new string[] {
                        "[[Person().Level]]",
                        "0.12"});
#line 83
 testRunner.Given("There is a complexobject in the datalist with this shape", ((string)(null)), table9, "Given ");
#line 88
 testRunner.And("Alias is \"[[bob]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("Datasource is \"[[Person(*).Level]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Rounding",
                        "Rounding Value",
                        "Decimals to show",
                        "Result"});
            table10.AddRow(new string[] {
                        "[[bob]]",
                        "Up",
                        "2",
                        "3",
                        "[[bob]]"});
#line 90
 testRunner.And("I use a Number Format tool configured as", ((string)(null)), table10, "And ");
#line 93
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.Then("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.And("\"[[Person(1).Level]]\" has a value of \"0.300\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("\"[[Person(2).Level]]\" has a value of \"0.450\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("\"[[Person(3).Level]]\" has a value of \"0.120\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute a selectAndApply over a tool using an empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void ExecuteASelectAndApplyOverAToolUsingAnEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute a selectAndApply over a tool using an empty recordset", ((string[])(null)));
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.Given("Alias is \"[[bob]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
 testRunner.And("Datasource is \"[[bs(*).field]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("the underlying dropped activity is \"Tool\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("the selectAndApply executes 0 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute a selectAndApply over a tool throws an error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SelectAndApply")]
        public virtual void ExecuteASelectAndApplyOverAToolThrowsAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute a selectAndApply over a tool throws an error", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.And("I drag a new Select and Apply tool to the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table11.AddRow(new string[] {
                        "[[rs().field]]",
                        "1"});
            table11.AddRow(new string[] {
                        "[[rs().field]]",
                        "2"});
            table11.AddRow(new string[] {
                        "[[rs().field]]",
                        "3"});
#line 112
 testRunner.Given("There is a recordset in the datalist with this shape", ((string)(null)), table11, "Given ");
#line 117
 testRunner.And("Alias is \"[[bob]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("Datasource is \"[[rs(*).field]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("the underlying dropped activity is \"Tool\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("the tool throws an error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.When("the selectAndApply tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
 testRunner.Then("the selectAndApply executes 3 times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "[[rs(*).field]]"});
            table12.AddRow(new string[] {
                        "As = [[bob]]"});
#line 124
 testRunner.And("the debug inputs as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
