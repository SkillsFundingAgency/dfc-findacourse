﻿using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class SearchResultsSteps : BaseTest
	{

		[Given(@"I am on the Search Results page")]
		public void NavigateToSearchResults()
		{
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            //PageInteractionHelper.VerifyPageHeading(By.TagName("h1"), "Search results for");
        }

		[Then(@"I should be on (.*) page")]
		public void ConfirmSearchResultsPage(string searchPage)
		{
			FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
			FindACourseSearchResultsPage.Equals(By.TagName("h1"), searchPage);
		}

        [Then(@"no results found message is displayed")]
        public void NoResultsFoundMessageIsDisplayed()
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.CheckNullResults();
        }

        [Then(@"Valid Results are returned")]
        public void ValidResultsAreReturned()
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.CheckResultsReturned();
        }

        [Then(@"Search (.*) displayed in location field")]
        public void SearchLocationDisplayedInLocationField(string location)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetSearchLocation(location);
        }

        [Then(@"the course title (.*) is displayed")]
        public void CourseTitleIsDisplayed(string courseTitle)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetCourseTitle(courseTitle);
        }

        [Then(@"the course level (.*) is displayed")]
        public void CourseLevelIsDisplayed(string courseLevel)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetCourseLevel(courseLevel);
        }

        [Then(@"the study mode (.*) is displayed")]
        public void StudyModeIsDisplayed(string studyMode)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetStudyMode(studyMode);
        }

        [Then(@"the attendance mode (.*) is displayed")]
        public void AttendanceModeIsDisplayed(string attendanceMode)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetAttendanceMode(attendanceMode);
        }

        [Then(@"the attendance pattern (.*) is displayed")]
        public void AttendancePatternIsDisplayed(string attendancePattern)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetAttendancePattern(attendancePattern);
        }

        [Then(@"the provider (.*) is displayed")]
        public void ProviderIsDisplayed(string provider)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetProvider(provider);
        }

        [Then(@"the location (.*) is dispalyed")]
        public void LocationIsDispalyed(string location)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetLocation(location);
        }

        [Then(@"the distance (.*) is displayed")]
        public void DistanceIsDisplayed(string distance)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetDistance(distance);
        }

        [Then(@"the start date (.*) is displayed")]
        public void StartDateIsDisplayed(string startDate)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetStartDate(startDate);
        }

        [Then(@"the duration (.*) is displayed")]
        public void DurationYearsIsDisplayed(string duration)
        {
            FindACourseSearchResultsPage findACourseSearchResultsPage = new FindACourseSearchResultsPage(webDriver);
            findACourseSearchResultsPage.GetDuration(duration);
        }


    }
}
