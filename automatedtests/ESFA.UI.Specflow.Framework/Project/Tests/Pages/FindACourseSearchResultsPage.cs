using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class FindACourseSearchResultsPage : BasePage
    {
        private static readonly String PAGE_TITLE = "Search results for";

        public FindACourseSearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
            //SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private readonly By noResultsErrorMsg = By.XPath(".//*[@id='FindACourseForm']");
        private readonly By courseTitle = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/h3/a");
        private readonly By courseLevel = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/div");
        private readonly By location = By.Name("Location");
        private readonly By studyMode = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[1]/li[1]");
        private readonly string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
        private readonly By attendanceMode = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[1]/li[2]");
        private readonly By attendancePattern = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[1]/li[3]");
        private readonly By provider = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[2]/li[1]/span[2]");
        private readonly By courseLocation = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[2]/li[2]/span[2]");
        private readonly By distance = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[2]/li[3]/span[2]");
        private readonly By startDate = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[2]/li[4]/span[2]");
        private readonly By duration = By.XPath(".//*[@id='FindACourseForm']/div[2]/div[2]/div[2]/div/div[1]/ul[2]/li[5]/span[2]");

        internal FindACourseSearchResultsPage CheckNullResults()
        {
            PageInteractionHelper.VerifyText(noResultsErrorMsg, errorString);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage CheckResultsReturned()
        {
            PageInteractionHelper.VerifyTextNotPresent(noResultsErrorMsg, errorString);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetSearchLocation(string Location)
        {
            PageInteractionHelper.VerifyEditFieldText(location, Location);
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

        internal FindACourseSearchResultsPage GetStudyMode(string StudyMode)
        {
            PageInteractionHelper.VerifyText(studyMode, StudyMode);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetAttendanceMode(string AttendanceMode)
        {
            PageInteractionHelper.VerifyText(attendanceMode, AttendanceMode);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetAttendancePattern(string AttendancePattern)
        {
            PageInteractionHelper.VerifyText(attendancePattern, AttendancePattern);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetProvider(string Provider)
        {
            PageInteractionHelper.VerifyText(provider, Provider);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetLocation(string Location)
        {
            PageInteractionHelper.VerifyText(courseLocation, Location);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetDistance(string Distance)
        {
            PageInteractionHelper.VerifyText(distance, Distance);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetStartDate(string StartDate)
        {
            PageInteractionHelper.VerifyText(startDate, StartDate);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage GetDuration(string Duration)
        {
            PageInteractionHelper.VerifyText(duration, Duration);
            return new FindACourseSearchResultsPage(webDriver);
        }

        internal FindACourseSearchResultsPage SelectFirstCourse()
        {
            ScenarioContext.Current["CourseTitle"] = webDriver.FindElement(courseTitle).GetAttribute("innerText");
            Console.WriteLine("course title: " + ScenarioContext.Current["CourseTitle"]);
            FormCompletionHelper.ClickElement(courseTitle);
            return new FindACourseSearchResultsPage(webDriver);

        }
    }
}