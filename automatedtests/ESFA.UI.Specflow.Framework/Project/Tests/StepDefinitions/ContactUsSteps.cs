using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class ContactUsSteps : BaseTest
	{

		[Given(@"I am on the Find a Course Search page")]
		public void NavigateToContactUs()
		{
			//webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
		}

		[Then(@"I will be on Contact us page")]
		public void ConfirmContactUsPage()
		{
			ContactUsPage findACoursePage = new ContactUsPage(webDriver);
			ContactUsPage.Equals(By.TagName("h1"), "Contact us");

		}

	}
}
