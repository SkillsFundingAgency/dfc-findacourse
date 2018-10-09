using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Collections.Specialized;
using OpenQA.Selenium.Remote;
using BrowserStack;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
	public class BrowserStackDriver
	{
		private IWebDriver driver;
		private Local browserStackLocal;
		private readonly ScenarioContext context;

		public BrowserStackDriver(ScenarioContext context)
		{
			this.context = context;
		}

		public IWebDriver Init(string profile, string environment)
		{
			NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
			NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

			DesiredCapabilities capability = new DesiredCapabilities();

			foreach (string key in caps.AllKeys)
			{
				capability.SetCapability(key, caps[key]);
			}

			foreach (string key in settings.AllKeys)
			{
				capability.SetCapability(key, settings[key]);
			}

			String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
			if (username == null)
			{
				username = ConfigurationManager.AppSettings.Get("user");
			}

			String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
			if (accesskey == null)
			{
				accesskey = ConfigurationManager.AppSettings.Get("key");
			}

			capability.SetCapability("browserstack.user", username);
			capability.SetCapability("browserstack.key", accesskey);

			//File.AppendAllText("C:\\Users\\kadir\\Desktop\\sf.log", "Starting local");

			if (capability.GetCapability("browserstack.local") != null && capability.GetCapability("browserstack.local").ToString() == "true")
			{
				browserStackLocal = new Local();
				List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
		new KeyValuePair<string, string>("key", accesskey)
	  };
				browserStackLocal.start(bsLocalArgs);
			}

			//File.AppendAllText("C:\\Users\\kadir\\Desktop\\sf.log", "Starting driver");
			driver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
			return driver;
		}

		public void Cleanup()
		{
			driver.Quit();
            if (browserStackLocal != null)
			{
				browserStackLocal.stop();
			}
		}
	}
}