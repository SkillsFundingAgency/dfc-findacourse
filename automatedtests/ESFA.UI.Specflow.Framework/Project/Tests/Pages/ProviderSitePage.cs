using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    class ProviderSitePage : BasePage
    {
        private static String PAGE_TITLE = "provider site";


        public ProviderSitePage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            if (!webDriver.Url.ToLower().StartsWith("http://"))
            {
                if (!webDriver.Url.ToLower().StartsWith("https://"))
                {
                    throw new Exception("Invalid URL provided");
                }
            }

            if (webDriver.Url.ToLower().Contains("nationalcareersservice.org.uk"))
            {
                throw new Exception("Invalid URL provided");
            }

            if (webDriver.PageSource.Contains("Status Code: 404; Not Found"))
            {
                throw new Exception("Invalid URL provided");
            }
           
           return PageInteractionHelper.VerifyPageTitle(this.webDriver.Title.ToString(), this.webDriver.Title.ToString());
		}
    }
}