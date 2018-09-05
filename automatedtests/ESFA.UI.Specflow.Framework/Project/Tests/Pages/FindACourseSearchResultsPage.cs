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
        private readonly By courseTitle = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/h3/a");
        private readonly By courseLevel = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/div");

        internal FindACourseSearchResultsPage CheckNullResults()
        {
            string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
            PageInteractionHelper.VerifyText(noResultsErrorMsg, errorString);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage CheckResultsReturned()
        {
            string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
            PageInteractionHelper.VerifyTextNotPresent(noResultsErrorMsg, errorString);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetCourseTitle(string CourseTitle)
        {
            PageInteractionHelper.VerifyText(courseTitle, CourseTitle);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetCourseLevel(string CourseLevel)
        {
            PageInteractionHelper.VerifyText(courseLevel, CourseLevel);
            return new FindACourseSearchResultsPage(webDriver);
        }
    }
}