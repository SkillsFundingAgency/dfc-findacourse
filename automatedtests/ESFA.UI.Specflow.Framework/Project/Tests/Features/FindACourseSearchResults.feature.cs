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
    [NUnit.Framework.DescriptionAttribute("Find A Course Search Results Page")]
    public partial class FindACourseSearchResultsPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FindACourseSearchResults.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Find A Course Search Results Page", "\tAs a user\r\n\tI am able to view and use the Search Results", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name Valid Results")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        public virtual void DFC3900ViewSearchResultsByCourseNameValidResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name Valid Results", null, new string[] {
                        "DFC-3900"});
#line 7
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I enter course Biology", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.And("Valid Results are returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name Null Results")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("bbbbbbbbb", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameNullResults(string courseName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name Null Results", null, @__tags);
#line 16
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 17
  testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
  testRunner.And("no results found message is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name display Course Title")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("Biology", "Biology", null)]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "Chemi", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplayCourseTitle(string courseName, string courseTitle, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name display Course Title", null, @__tags);
#line 29
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
  testRunner.And(string.Format("the course title {0} is displayed", courseTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name display Course Level")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("English Bridging Course Entry Level", "Entry level", null)]
        [NUnit.Framework.TestCaseAttribute("Diploma in Chemical Skin Peeling & Micro-needling", "Level 4", null)]
        [NUnit.Framework.TestCaseAttribute("ASTROPHYSICS", "Level 3", null)]
        [NUnit.Framework.TestCaseAttribute("DENTISTRY", "Level 2", null)]
        [NUnit.Framework.TestCaseAttribute("C&G L1 AWARD IN INTRODUCTORY TUNGSTEN INERT GAS (TIG) WELDING", "Level 1", null)]
        [NUnit.Framework.TestCaseAttribute("Pharmacy Clinical Services Professional Diploma", "Level 4", null)]
        [NUnit.Framework.TestCaseAttribute("Marine Engineering - HND", "Level 5", null)]
        [NUnit.Framework.TestCaseAttribute("Integrated Masters Equine Science MSci", "Level 7", null)]
        [NUnit.Framework.TestCaseAttribute("Automotive Engineering and Technology (Motorsport) - BEng Hons Degree - Topup", "Level 6", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplayCourseLevel(string courseName, string courseLevel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name display Course Level", null, @__tags);
#line 43
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 44
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
  testRunner.And(string.Format("the course level {0} is displayed", courseLevel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name display Study Mode")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("A-level Maths", "Full-time", null)]
        [NUnit.Framework.TestCaseAttribute("General Data Protection Regulation (ONLINE)", "Flexible", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplayStudyMode(string courseName, string studyMode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name display Study Mode", null, @__tags);
#line 64
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 65
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
  testRunner.And("I click  the Clear All Filters link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.When(string.Format("I select {0} filter", studyMode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
  testRunner.Then(string.Format("the study mode {0} is displayed", studyMode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Attendance Mode")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("A Level Biology or Human Biology", "Classroom-based", null)]
        [NUnit.Framework.TestCaseAttribute("General Data Protection Regulation (ONLINE)", "Online/Distance learning", null)]
        [NUnit.Framework.TestCaseAttribute("Management - Apprenticeship (Higher) - Level 4", "Work-based", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysAttendanceMode(string courseName, string attendanceMode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Attendance Mode", null, @__tags);
#line 81
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 82
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
  testRunner.And(string.Format("the attendance mode {0} is displayed", attendanceMode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Attendance Pattern")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("NVQ 3 Diploma Nail Services - Day release (Apprentice Route)", "Normal working hours", null)]
        [NUnit.Framework.TestCaseAttribute("arabic", "Evening/Weekend", null)]
        [NUnit.Framework.TestCaseAttribute("Management - Apprenticeship (Higher) - Level 4", "Day release/Block release", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysAttendancePattern(string courseName, string attendancePattern, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Attendance Pattern", null, @__tags);
#line 96
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 97
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.And(string.Format("the attendance pattern {0} is displayed", attendancePattern), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Provider")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("urdu", "Batley Girls\' High School - Visual Arts College", null)]
        [NUnit.Framework.TestCaseAttribute("CYBER SECURITY", "Walsall College", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysProvider(string courseName, string provider, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Provider", null, @__tags);
#line 111
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 112
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
  testRunner.And(string.Format("the provider {0} is displayed", provider), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Location")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("Biology", "L3 5TP", null)]
        [NUnit.Framework.TestCaseAttribute("Chemistry", "ME4 4TB", null)]
        [NUnit.Framework.TestCaseAttribute("Certificate/Diploma for Entry to the Uniformed Public Services", "United Kingdom", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysLocation(string courseName, string location, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Location", null, @__tags);
#line 125
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 126
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
  testRunner.And(string.Format("the location {0} is dispalyed", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Distance")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("geography", "EC1A 1BB", "6.9", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysDistance(string courseName, string location, string distance, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Distance", null, @__tags);
#line 140
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 141
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 142
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
  testRunner.And(string.Format("the distance {0} is displayed", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3900 View Search Results By Course Name displays Start Date and Duration")]
        [NUnit.Framework.CategoryAttribute("DFC-3900")]
        [NUnit.Framework.TestCaseAttribute("geography", "EC1A 1BB", "6.9", "1 September 2018", "2 Years", null)]
        public virtual void DFC3900ViewSearchResultsByCourseNameDisplaysStartDateAndDuration(string courseName, string location, string distance, string startDate, string duration, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3900"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3900 View Search Results By Course Name displays Start Date and Duration", null, @__tags);
#line 154
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 155
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
  testRunner.And(string.Format("the distance {0} is displayed", distance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
  testRunner.And(string.Format("the start date {0} is displayed", startDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
  testRunner.And(string.Format("the duration {0} is displayed", duration), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3935 Select location on Page 2")]
        [NUnit.Framework.CategoryAttribute("DFC-3934")]
        [NUnit.Framework.TestCaseAttribute("maths", "EC1A 1BB", "BS1 1JG", null)]
        [NUnit.Framework.TestCaseAttribute("english", "EC1A 1BB", "NE7 7SF", null)]
        [NUnit.Framework.TestCaseAttribute("biology", "EC1A 1BB", "M9 0FN", null)]
        [NUnit.Framework.TestCaseAttribute("computing", "EC1A 1BB", "L4 1SE", null)]
        [NUnit.Framework.TestCaseAttribute("history", "EC1A 1BB", "S1 2HE", null)]
        [NUnit.Framework.TestCaseAttribute("safety", "EC1A 1BB", "BD1 1AJ", null)]
        public virtual void DFC3935SelectLocationOnPage2(string courseName, string location, string location2, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3934"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3935 Select location on Page 2", null, @__tags);
#line 170
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 171
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 172
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
  testRunner.And(string.Format("I enter location {0}", location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
  testRunner.When(string.Format("On Page 2 I enter location {0}", location2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
  testRunner.And("On Page 2 I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DFC3935 Select Course Name on Page 2")]
        [NUnit.Framework.CategoryAttribute("DFC-3935")]
        [NUnit.Framework.TestCaseAttribute("geography", "biology", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "team building", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "NURSING", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "ENGINEERING", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "A LEVEL CHEMISTRY", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "NVQ HAIR & BEAUTY", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "GCSE MATHS", null)]
        [NUnit.Framework.TestCaseAttribute("geography", "LEVEL 4 EDUCATION", null)]
        public virtual void DFC3935SelectCourseNameOnPage2(string courseName, string courseName2, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DFC-3935"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DFC3935 Select Course Name on Page 2", null, @__tags);
#line 192
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 193
 testRunner.Given("I navigate to Find a Course home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 194
  testRunner.When(string.Format("I enter course {0}", courseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 195
  testRunner.And("I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 197
  testRunner.When(string.Format("On Page 2 I enter course {0}", courseName2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 198
  testRunner.And("On Page 2 I click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
  testRunner.Then("I should be on Search Results for page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
