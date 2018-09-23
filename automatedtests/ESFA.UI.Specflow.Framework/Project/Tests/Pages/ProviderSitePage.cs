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
          //  SelfVerify();
        }

        protected override bool SelfVerify()
        {
           return PageInteractionHelper.VerifyPageTitle(this.webDriver.Title.ToString(), PAGE_TITLE);
		}
    }
}