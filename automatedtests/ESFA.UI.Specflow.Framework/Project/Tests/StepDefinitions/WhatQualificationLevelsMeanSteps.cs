using System;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class WhatQualificationLevelsMeanSteps : BaseTest
	{

		[Given(@"I am on the Find a Course Search page")]
		public void NavigateWhatQualificationLevelsMean()
		{
			//webDriver.Url = Configurator.GetConfiguratorInstance().GetBaseUrl();
		}

		[Then(@"I will be on What qualification levels mean page")]
		public void ConfirmWhatQualificationLevelsMean()
		{
            WindowHelper.SwitchToNewWindow(webDriver);
            WhatQualificationLevelsMeanPage whatQualificationLevelsMeanPage = new WhatQualificationLevelsMeanPage(webDriver);
            WhatQualificationLevelsMeanPage.Equals(By.TagName("h1"), "What qualification levels mean");

        }

	}
}
