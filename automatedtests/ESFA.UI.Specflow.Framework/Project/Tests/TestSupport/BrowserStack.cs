using System;
using System.Diagnostics;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
	[Binding]
	public sealed class BrowserStack
	{
		private BrowserStackDriver bsDriver;

		[BeforeScenario]
		[Scope(Tag = "BrowserStack")]
		public void BeforeScenario()
		{
			bsDriver = new BrowserStackDriver(ScenarioContext.Current);
			ScenarioContext.Current["bsDriver"] = bsDriver;
		}

		[AfterScenario]
		[Scope(Tag = "BrowserStack")]
		public void AfterScenario()
		{
            bsDriver.Cleanup();
            Process[] chromeInstances = Process.GetProcessesByName("chrome");

            foreach (Process p in chromeInstances)
                p.Kill();
        }
	}
}
