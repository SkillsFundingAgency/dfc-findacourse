using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class FindACourseSteps : BaseTest
    {


		[Given(@"I navigate to Find a Course home page")]
		public void NavigateToFindACoursePage()
		{
			webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
			WelcomeToGovUkPage welcomeToGovUkPage = new WelcomeToGovUkPage(webDriver);
		}

		[When(@"I enter course (.*)")]
		public void WhenIEnterCourse(string p0)
		{
			ScenarioContext.Current.Pending();
		}


		[When(@"I enter qualification (.*)")]
		public void WhenIEnterQualification(string p0)
		{
			ScenarioContext.Current.Pending();
		}


		[When(@"I enter location (.*)")]
		public void WhenIEnterLocation(string p0)
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"I enter postcode (.*)")]
		public void WhenIEnterPostcode(string p0)
		{
			ScenarioContext.Current.Pending();
		}


		//[When(@"I search for (.*)")]
		//      public void SearchForText(String searchText)
		//      {
		//          WelcomeToGovUkPage welcomeToGovUkPage = new WelcomeToGovUkPage(webDriver);
		//          welcomeToGovUkPage.EnterSearchTextAndSubmit(searchText);
		//      }

		//      [When(@"I click on DFE link")]
		//      public void ClickOnDfeLink()
		//      {
		//          SearchResultsPage searchResultsPage = new SearchResultsPage(webDriver);
		//          searchResultsPage.ClickDfeLink();
		//      }

		////km [Then(@"I should be on DFE home page")]
		//[Then(@"I should be on (.*) home page")]
		//public void ShouldBeOnDfeHomePage(string onPage)
		//      {
		//	//PageInteractionHelper.VerifyPageHeading(By.TagName("h1"), "Department for Education");
		//	PageInteractionHelper.VerifyPageHeading(By.TagName("h1"), onPage);
		//}
	}
}