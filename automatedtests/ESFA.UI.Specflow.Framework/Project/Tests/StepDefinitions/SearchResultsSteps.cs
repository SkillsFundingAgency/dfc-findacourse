using System;
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

    }
}
