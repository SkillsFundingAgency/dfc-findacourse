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
    [NUnit.Framework.DescriptionAttribute("Find A Course Search Page")]
    public partial class FindACourseSearchPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FindACourse.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Find A Course Search Page", "\tAs a user\r\n\tI am able to access and use the Find a Course Page", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("DFC-3885 Select Location and Distance")]
        [NUnit.Framework.CategoryAttribute("DFC-3885")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "b13 9da", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "B13 9DA", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "b13 9da", "5 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("English", "b13 9da", "10 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "b13 9da", "15 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "b13 9da", "20 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "b13 9da", "National", null)]
        public virtual void DFC_3885SelectLocationAndDistance(string courseName, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3885"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3885 Select Location and Distance", null, @__tags);
#line 6
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4090 Search for Courses By Location & Distance")]
        [NUnit.Framework.CategoryAttribute("DFC-4090")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "b13 9da", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "B13 9DA", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "B14 7EN", "5 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("English", "b14 7rn", "10 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "b14 7rz", "15 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "b13 8py", "20 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "b13 9ah", "National", null)]
        public virtual void DFC_4090SearchForCoursesByLocationDistance(string courseName, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-4090"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4090 Search for Courses By Location & Distance", null, @__tags);
#line 24
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 25
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
  testRunner.And(string.Format("Search {0} displayed in location field", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4090 Search for Courses By Location & Distance Invalid Location")]
        [NUnit.Framework.CategoryAttribute("DFC-4090")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "honalulu", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "x99 9xx", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "davy st, edinburgh", "5 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("English", "xxxxxxxxx", "10 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "wherever", "15 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "anywhere", "20 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "nowhere", "National", null)]
        public virtual void DFC_4090SearchForCoursesByLocationDistanceInvalidLocation(string courseName, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-4090"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4090 Search for Courses By Location & Distance Invalid Location", null, @__tags);
#line 45
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 46
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.Then("postcode validation failure message is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4090 Search for Courses By Location & Distance Null Results")]
        [NUnit.Framework.CategoryAttribute("DFC-4090")]
        [NUnit.Framework.TestCaseAttribute("ARCHAEOLOGIST", "PO30 1DN", "1 Mile", null)]
        public virtual void DFC_4090SearchForCoursesByLocationDistanceNullResults(string courseName, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-4090"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4090 Search for Courses By Location & Distance Null Results", null, @__tags);
#line 65
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 66
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
  testRunner.And("no results found message is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3884 Select Qualification Level")]
        [NUnit.Framework.CategoryAttribute("DFC-3884")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Entry level - Skills for Life", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "Level 1 - First certificate", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "Level 2 - GCSE/O level", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Level 3 - A level/Access to higher education diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "Level 4 - Certificate of higher education/HNC", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "Level 5 - Foundation degree/HND", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "Level 6 - Degree/Graduate diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Biology", "Level 7 - Masters Degree/Postgraduate diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Physics", "Level 8 - Doctorate/PhD", null)]
        public virtual void DFC_3884SelectQualificationLevel(string courseName, string qualificationLevel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3884"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3884 Select Qualification Level", null, @__tags);
#line 80
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 81
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3884 Select Qualification Level Default Value")]
        [NUnit.Framework.CategoryAttribute("DFC-3884")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Entry level - Skills for Life", null)]
        public virtual void DFC_3884SelectQualificationLevelDefaultValue(string courseName, string qualificationLevel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3884"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3884 Select Qualification Level Default Value", null, @__tags);
#line 99
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 100
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
  testRunner.And("Qualification Level field displays default Select level", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4091 Search for Courses By Qualification Level")]
        [NUnit.Framework.CategoryAttribute("DFC-4091")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Entry level - Skills for Life", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "Level 1 - First certificate", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "Level 2 - GCSE/O level", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Level 3 - A level/Access to higher education diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "Level 4 - Certificate of higher education/HNC", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "Level 5 - Foundation degree/HND", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "Level 6 - Degree/Graduate diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Biology", "Level 7 - Masters Degree/Postgraduate diploma", null)]
        [NUnit.Framework.TestCaseAttribute("Physics", "Level 8 - Doctorate/PhD", null)]
        public virtual void DFC_4091SearchForCoursesByQualificationLevel(string courseName, string qualificationLevel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-4091"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4091 Search for Courses By Qualification Level", null, @__tags);
#line 110
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 111
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4091 Search for Courses By Qualification Level Null Results")]
        [NUnit.Framework.CategoryAttribute("DFC-4091")]
        [NUnit.Framework.TestCaseAttribute("ARCHEOLOGY", "Entry level - Skills for Life", null)]
        public virtual void DFC_4091SearchForCoursesByQualificationLevelNullResults(string courseName, string qualificationLevel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-4091"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4091 Search for Courses By Qualification Level Null Results", null, @__tags);
#line 131
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 132
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 133
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
  testRunner.And("no results found message is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3888 Search for Courses By Course Name All Options")]
        [NUnit.Framework.CategoryAttribute("DFC-3888")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Entry level - Skills for Life", "AB1 0AA", "1 Mile", null)]
        [NUnit.Framework.TestCaseAttribute("Bricklaying", "Level 1 - First certificate", "BB1 1AB", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Maths", "Level 2 - GCSE/O level", "CM0 7AE", "5 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Level 3 - A level/Access to higher education diploma", "G1 1AB", "10 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", "Level 4 - Certificate of higher education/HNC", "LS1 1AA", "15 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Electronic", "Level 5 - Foundation degree/HND", "ZE1 0AD", "20 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Medicine", "Level 6 - Degree/Graduate diploma", "SW10 0AA", "National", null)]
        [NUnit.Framework.TestCaseAttribute("Biology", "Level 7 - Masters Degree/Postgraduate diploma", "b13 8py", "3 Miles", null)]
        [NUnit.Framework.TestCaseAttribute("Physics", "Level 8 - Doctorate/PhD", "n1 0aj", "5 Miles", null)]
        public virtual void DFC_3888SearchForCoursesByCourseNameAllOptions(string courseName, string qualificationLevel, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3888"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3888 Search for Courses By Course Name All Options", null, @__tags);
#line 145
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 146
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
  testRunner.And(string.Format("I select qualification {0}", qualificationLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
  testRunner.And(string.Format("I select distance {0}", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3888 Search for Courses By Course Name Only")]
        [NUnit.Framework.CategoryAttribute("DFC-3888")]
        [NUnit.Framework.TestCaseAttribute("Chemistry", null)]
        [NUnit.Framework.TestCaseAttribute("chemsitry 1", null)]
        [NUnit.Framework.TestCaseAttribute("CHEMISTRY", null)]
        [NUnit.Framework.TestCaseAttribute("PLUMMING", null)]
        [NUnit.Framework.TestCaseAttribute("Plumbing", null)]
        [NUnit.Framework.TestCaseAttribute("PLUMING", null)]
        [NUnit.Framework.TestCaseAttribute("BRICKLAYER.", null)]
        [NUnit.Framework.TestCaseAttribute("BRICK+LAYER", null)]
        [NUnit.Framework.TestCaseAttribute("hair and beuaty", null)]
        [NUnit.Framework.TestCaseAttribute("Hair & Beauty", null)]
        [NUnit.Framework.TestCaseAttribute("(Hair and Beuaty)", null)]
        [NUnit.Framework.TestCaseAttribute("hair beauty\'", null)]
        [NUnit.Framework.TestCaseAttribute("a level biology,", null)]
        [NUnit.Framework.TestCaseAttribute("A LEVEL BIOLOGY:", null)]
        [NUnit.Framework.TestCaseAttribute("hair/beauty", null)]
        public virtual void DFC_3888SearchForCoursesByCourseNameOnly(string courseName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3888"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3888 Search for Courses By Course Name Only", null, @__tags);
#line 168
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 169
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 170
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 171
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3888 Search for Courses using illegal Chars")]
        [NUnit.Framework.CategoryAttribute("DFC-3888")]
        [NUnit.Framework.TestCaseAttribute("Chemistry!", null)]
        [NUnit.Framework.TestCaseAttribute("chemsitry;", null)]
        [NUnit.Framework.TestCaseAttribute("CHEMISTRY^", null)]
        [NUnit.Framework.TestCaseAttribute("\"PLUMMING\"", null)]
        [NUnit.Framework.TestCaseAttribute("@Plumbing", null)]
        [NUnit.Framework.TestCaseAttribute("{PLUMING}", null)]
        [NUnit.Framework.TestCaseAttribute("BRICK=LAYER", null)]
        [NUnit.Framework.TestCaseAttribute("hairbeuaty?", null)]
        [NUnit.Framework.TestCaseAttribute("Hair & Beauty %", null)]
        [NUnit.Framework.TestCaseAttribute("(Hair £ Beuaty)", null)]
        [NUnit.Framework.TestCaseAttribute("#hair beauty", null)]
        [NUnit.Framework.TestCaseAttribute("a level biology*", null)]
        [NUnit.Framework.TestCaseAttribute("A~LEVEL BIOLOGY", null)]
        [NUnit.Framework.TestCaseAttribute("hair_beauty", null)]
        public virtual void DFC_3888SearchForCoursesUsingIllegalChars(string courseName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3888"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3888 Search for Courses using illegal Chars", null, @__tags);
#line 194
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 195
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 196
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 197
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
  testRunner.Then("I should be shown a validation error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3888 Search for Courses By Course Name Null Results")]
        [NUnit.Framework.CategoryAttribute("DFC-3888")]
        [NUnit.Framework.TestCaseAttribute("bbbbbbbbb", null)]
        [NUnit.Framework.TestCaseAttribute("1234567890", null)]
        [NUnit.Framework.TestCaseAttribute("aaBBccDD123", null)]
        [NUnit.Framework.TestCaseAttribute("aaaBB cDD23", null)]
        [NUnit.Framework.TestCaseAttribute("(aaBBccDD123)", null)]
        public virtual void DFC_3888SearchForCoursesByCourseNameNullResults(string courseName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3888"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3888 Search for Courses By Course Name Null Results", null, @__tags);
#line 218
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 219
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 220
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 221
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 222
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 223
  testRunner.And("no results found message is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3883 Auto Populate Course Name")]
        [NUnit.Framework.CategoryAttribute("DFC-3883")]
        [NUnit.Framework.TestCaseAttribute("team", "TEAM,TEAM BUILDING,TEAM WORK,TEAM WORKING,TEAMWORK,TEAMWORKING", null)]
        [NUnit.Framework.TestCaseAttribute("builder", "BUILDER,BUILDING,BUILDING MAINTENANCE,BUILDING SERVICES,BUILDING SERVICES ENGINEE" +
            "RING,BUILDING SURVEYING,CONSTRUCTION", null)]
        public virtual void DFC_3883AutoPopulateCourseName(string courseName, string autopopulateList, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3883"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3883 Auto Populate Course Name", null, @__tags);
#line 235
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 236
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 237
  testRunner.When(string.Format("one letter at a time {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 238
  testRunner.Then(string.Format("the Course suggestions {0} displayed", autopopulateList), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 239
  testRunner.And(string.Format("I Can select one of the List options {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 240
  testRunner.When("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 241
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-4094 Contact Adviser")]
        [NUnit.Framework.CategoryAttribute("DFC-4094")]
        public virtual void DFC_4094ContactAdviser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-4094 Contact Adviser", null, new string[] {
                        "DFC-4094"});
#line 251
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 252
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 253
 testRunner.When("I click Contact a careers adviser link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 254
 testRunner.Then("I will be on Contact us page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC-3887 View Qualification Level Help Text")]
        [NUnit.Framework.CategoryAttribute("DFC-3887")]
        public virtual void DFC_3887ViewQualificationLevelHelpText()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC-3887 View Qualification Level Help Text", null, new string[] {
                        "DFC-3887"});
#line 258
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 259
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 260
 testRunner.When("I click What qualification levels mean link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 261
 testRunner.Then("I will be on What qualification levels mean page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
