using System.Threading;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class AdvancedLearnerSteps : BaseTest
	{

		[Given(@"I am on the Find a Course Search page")]
		public void NavigateToAdvancedLearnerPage()
		{
			//webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
		}

		[Then(@"I will be on the advanced learner loan page")]
		public void ConfirmAdvancedLearnerPage()
		{
            Thread.Sleep(3000);
            WindowHelper.SwitchToNewWindow(webDriver);
            AdvancedLearnerLoansPage advancedLearnerLoansPage = new AdvancedLearnerLoansPage(webDriver);
            AdvancedLearnerLoansPage.Equals(By.TagName("h1"), "Advanced Learner Loan");
        }

	}
}
