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
            FindACourseSearchResultsPage findACoursePage = new FindACourseSearchResultsPage(webDriver);
            //PageInteractionHelper.VerifyPageHeading(By.TagName("h1"), "Search results for");
        }


		[Then(@"I should be on (.*) page")]
		public void ConfirmSearchResultsPage(string searchPage)
		{
			FindACourseSearchResultsPage findACoursePage = new FindACourseSearchResultsPage(webDriver);
			FindACourseSearchResultsPage.Equals(By.TagName("h1"), searchPage);
		}

	}
}
