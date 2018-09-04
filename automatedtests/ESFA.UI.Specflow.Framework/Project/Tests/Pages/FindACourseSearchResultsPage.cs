using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class FindACourseSearchResultsPage : BasePage
    {
        private static String PAGE_TITLE = "Search results for";

        public FindACourseSearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private readonly By noResultsErrorMsg = By.XPath(".//*[@id='FindACourseForm']");

        internal FindACourseSearchResultsPage CheckNullResults()
        {
            string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
            PageInteractionHelper.VerifyText(noResultsErrorMsg, errorString);
            return new FindACourseSearchResultsPage(webDriver);
        }
    }
}