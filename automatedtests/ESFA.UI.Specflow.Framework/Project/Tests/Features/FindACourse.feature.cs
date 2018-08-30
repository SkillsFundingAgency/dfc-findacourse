﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ESFA.UI.Specflow.Framework.FindACourse.Project.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Find A Course")]
    public partial class FindACourseFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FindACourse.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Find A Course", "\tAs a user\r\n\tI am able to access and use the Find a Course Page", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User search on Find a Course page")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Entry level - Skills for Life", "Birmingham", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "Level 2 - GCSE/O level", "London", "5 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Level 3 - A level/Access to higher education diploma", "Birmingham", "10 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "Level 4 - Certificate of higher education/HNC", "London", "15 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "Level 5 - Foundation degree/HND", "London", "20 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "Level 6 - Degree/Graduate diploma", "Birmingham", "National", null)]
        [NUnit.Framework.TestCaseAttribute("Biology", "Level 7 - Masters Degree/Postgraduate diploma", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Physics", "Level 8 - Doctorate/PhD", "London", "5 Miles", null)]
        public virtual void UserSearchOnFindACoursePage(string courseName, string qualificationLevel, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User search on Find a Course page", null, @__tags);
#line 6
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User search on Find a Course page using Autopopulate")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("team", "TEAM,TEAM BUILDING,TEAM WORK,TEAM WORKING,TEAMWORK,TEAMWORKING", null)]
        [NUnit.Framework.TestCaseAttribute("builder", "BUILDER,BUILDING,BUILDING MAINTENANCE,BUILDING SERVICES,BUILDING SERVICES ENGINEE" +
            "RING,BUILDING SURVEYING,CONSTRUCTION", null)]
        public virtual void UserSearchOnFindACoursePageUsingAutopopulate(string courseName, string autopopulateList, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User search on Find a Course page using Autopopulate", null, @__tags);
#line 29
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
  testRunner.When(string.Format("one letter at a time {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
  testRunner.Then(string.Format("the Course suggestions {0} displayed", autopopulateList), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
  testRunner.And("I Can select one of the List options", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User contacts adviser from Find a Course page")]
        [NUnit.Framework.CategoryAttribute("regression")]
        public virtual void UserContactsAdviserFromFindACoursePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User contacts adviser from Find a Course page", null, new string[] {
                        "regression"});
#line 44
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 45
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
  testRunner.When("I click Contact an adviser link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
  testRunner.Then("I will be on Contact us page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User wants more information on Qualifications")]
        [NUnit.Framework.CategoryAttribute("regression")]
        public virtual void UserWantsMoreInformationOnQualifications()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User wants more information on Qualifications", null, new string[] {
                        "regression"});
#line 51
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 52
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
  testRunner.When("I click What qualification levels mean link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
  testRunner.Then("I will be on What qualification levels mean page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("BrowserStack Test Find a Course")]
        [NUnit.Framework.CategoryAttribute("BrowserStack")]
        [NUnit.Framework.TestCaseAttribute("single", "chrome", "Chemistry", "Entry level - Skills for Life", "Birmingham", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "safari", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "chrome", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "firefox", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "ie", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "edge", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "chromeios", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("parallel", "chromeandroid", "Bricklaying", "Level 1 - First certificate", "London", "3 Miles", null)]
        public virtual void BrowserStackTestFindACourse(string profile, string environment, string courseName, string qualificationLevel, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "BrowserStack"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("BrowserStack Test Find a Course", null, @__tags);
#line 59
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 60
  testRunner.Given(string.Format("I am on Find a Course for {0} and {1}", profile, environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
