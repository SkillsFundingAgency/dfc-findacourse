using System.Threading;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
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
            Thread.Sleep(3000);
            WindowHelper.SwitchToNewWindow(webDriver);
            ContactUsPage contactUsPage = new ContactUsPage(webDriver);
            ContactUsPage.Equals(By.TagName("h1"), "Contact us");
        }

	}
}
