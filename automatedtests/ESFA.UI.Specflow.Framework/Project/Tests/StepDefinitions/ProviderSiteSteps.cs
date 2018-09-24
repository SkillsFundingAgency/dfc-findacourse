using System.Threading;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class ProviderSiteSteps : BaseTest
	{

		[Given(@"I am on the Provider site page")]
		public void NavigateToProviderSite()
		{
			//webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
		}

		[Then(@"I am on the provider website")]
		public void ConfirmProviderSite()
		{
            Thread.Sleep(3000);
            WindowHelper.SwitchToNewWindow(webDriver);
            ProviderSitePage providerSitePage = new ProviderSitePage(webDriver);
        }
    }
}
