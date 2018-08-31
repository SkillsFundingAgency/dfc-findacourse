using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class FindACourseSteps : BaseTest
    {
        private IWebDriver _driver;
        private BrowserStackDriver _bsDriver;
        private IWebElement listContainer;


       // [Scope(Tag = "Regression")]
        [Given(@"I navigate to Find a Course home page")]
        public void NavigateToFindACourseHomePage()
        {
            webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
        }


        [Scope(Tag = "BrowserStack")]
        [Given(@"I am on Find a Course for (.*) and (.*)")]
        public void BSNavigateToFindACourseHomePage(string profile, string environment)
        {
            _bsDriver = (BrowserStackDriver)ScenarioContext.Current["bsDriver"];
            _driver = _bsDriver.Init(profile, environment);
            _driver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
            webDriver = _driver;

            PageInteractionHelper.SetDriver(webDriver);
        }


        [When(@"I enter course (.*)")]
        public void EnterCourse(string courseTxt)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.EnterCourseName(courseTxt);
        }


        [When(@"one letter at a time (.*)")]
        public void EnterOneLetterAtATime(string courseTxt)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            foreach (char c in courseTxt)
            {
                findACoursePage.EnterCourseNameWithoutClearing(c.ToString());
                Thread.Sleep(500);
            }
        }


        [When(@"I select qualification (.*)")]
        public void SelectQualification(string qualification)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.SelectQualification(qualification);
        }


        [When(@"I enter location (.*)")]
        public void EnterLocation(string location)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.EnterLocation(location);
        }


        [When(@"I select distance (.*)")]
        public void SelectDistance(string distance)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.SelectDistance(distance);
        }


        [When(@"I click Search")]
        public void ClickSearch()
        {
            webDriver.FindElement(By.Name("Search")).Submit();
        }


        [When(@"I click (.*) link")]
        public void ClickLinkonFindACoursePage(string linkToClick)
        {
            webDriver.FindElement(By.LinkText(linkToClick)).Click();
        }


        [Then(@"the Course suggestions (.*) displayed")]
        public void AutoPopulateList(string autopopulateList)
        {
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.CheckCourseList(autopopulateList);
         }


        [Then(@"I Can select one of the List options (.*)")]
        public void ThenICanSelectOneOfTheListOptions(string course)
        {
            course = course.ToUpper();
            FindACoursePage findACoursePage = new FindACoursePage(webDriver);
            findACoursePage.SelectCourse(course);
        }

    }
}