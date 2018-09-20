using System.Threading;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class GoogleMapsSteps : BaseTest
	{

		[Given(@"I am on the Google Maps page")]
		public void NavigateToGoogleMaps()
		{
			//webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
		}

		[Then(@"I will be on Google Maps page")]
		public void ConfirmGoogleMapsPage()
		{
            Thread.Sleep(3000);
            WindowHelper.SwitchToNewWindow(webDriver);
            GoogleMapsPage contactUsPage = new GoogleMapsPage(webDriver);
         }

	}
}
