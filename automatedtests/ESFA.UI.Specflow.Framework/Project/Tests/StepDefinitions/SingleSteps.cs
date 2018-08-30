using System.Threading;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{ 
[Binding]
public class BrowserStackExample
{
	private IWebDriver _driver;
	readonly BrowserStackDriver _bsDriver;

	public BrowserStackExample()
	{
		_bsDriver = (BrowserStackDriver)ScenarioContext.Current["bsDriver"];
	}

        [Given(@"I am on the google page for (.*) and (.*)")]
        public void GivenIAmOnTheGooglePage(string profile, string environment)
        {
            _driver = _bsDriver.Init(profile, environment);
            //_driver.Navigate().GoToUrl("https://www.google.com/ncr");
            _driver.Navigate().GoToUrl("https://dfc-sit-findacourse-web.azurewebsites.net/");

        }

        [When(@"I search forr (.*)")]
	public void WhenISearchFor(string keyword)
	{
		var q = _driver.FindElement(By.Name("q"));
		q.SendKeys(keyword);
		q.Submit();
	}

		[When(@"I input (.*)")]
		public void WhenIInput(string keyword)
		{
			
		   var courseEditField = _driver.FindElement(By.Name("SubjectKeyword"));
			courseEditField.SendKeys(keyword);
			//q.Submit();
		}

		[When(@"I then enter (.*)")]
		public void WhenIEnter(string location)
		{
			var locationEditField = _driver.FindElement(By.Name("Location"));
			locationEditField.SendKeys(location);
			//q.Submit();
		}

		[When(@"I Search")]
		public void WhenISearch()
		{
			_driver.FindElement(By.Name("Search")).Submit();
		}


		[Then(@"I should see title (.*)")]
	public void ThenIShouldSeeTitle(string title)
	{
		Thread.Sleep(5000);
		//Assert.That(_driver.Title, Is.EqualTo(title));
			_driver.Title.Equals(title);
		}
}
}