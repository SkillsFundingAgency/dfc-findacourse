﻿using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class FindACourseCourseDetailsPage : BasePage
    {
        private static readonly String PAGE_TITLE = "Course description";

        public FindACourseCourseDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(courseDetailsPage, PAGE_TITLE);
        }

        private readonly By courseDetailsPage = By.TagName("h2");
        private readonly By noResultsErrorMsg = By.XPath(".//*[@id='FindACourseForm']");
        private readonly string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
        private readonly By courseTitle = By.XPath(".//*[@id='content']/div[2]/div[1]/h1");
        private readonly By qualification = By.XPath(".//*[@id='1']/table/tbody/tr[1]/td[2]");
        private readonly By entryRequirements = By.XPath(".//*[@id='1']/table/tbody/tr[2]/td[2]");
        private readonly By cost = By.XPath(".//*[@id='1']/table/tbody/tr[3]/td[2]");
        private readonly By advancedlink = By.PartialLinkText("Advanced Learner");
        private readonly By startDate = By.XPath(".//*[@id='1']/table/tbody/tr[4]/td[2]");
        private readonly By duration = By.XPath(".//*[@id='1']/table/tbody/tr[5]/td[2]");
        private readonly By studyMode = By.XPath(".//*[@id='1']/table/tbody/tr[6]/td[2]");
        private readonly By attendancePattern = By.XPath(".//*[@id='1']/table/tbody/tr[7]/td[2]");
        private readonly By attendanceMode = By.XPath(".//*[@id='1']/table/tbody/tr[8]/td[2]");


        internal FindACourseCourseDetailsPage CheckNullResults()
        {
            PageInteractionHelper.VerifyText(noResultsErrorMsg, errorString);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage CheckResultsReturned()
        {
            PageInteractionHelper.VerifyTextNotPresent(noResultsErrorMsg, errorString);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetCourseTitle()
        {
            PageInteractionHelper.VerifyPageHeading(courseTitle, ScenarioContext.Current["CourseTitle"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetQualification(string Qualification)
        {
            PageInteractionHelper.VerifyText(qualification, Qualification);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetEntryRequirements(string EntryRequirements)
        {
            PageInteractionHelper.VerifyText(entryRequirements, EntryRequirements);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetCost(string Cost)
        {
            PageInteractionHelper.VerifyText(cost, Cost);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage ClickAdvancedlearnerlink()
        {
            FormCompletionHelper.ClickElement(advancedlink);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetStartDate()
        {
            PageInteractionHelper.VerifyText(startDate, ScenarioContext.Current["StartDate"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetDuration()
        {
            PageInteractionHelper.VerifyText(duration, ScenarioContext.Current["Duration"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetStudyMode()
        {
            PageInteractionHelper.VerifyText(studyMode, ScenarioContext.Current["StudyMode"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetAttendancePattern()
        {
            PageInteractionHelper.VerifyText(attendancePattern, ScenarioContext.Current["AttendancePattern"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetAttendanceMode()
        {
            PageInteractionHelper.VerifyText(attendanceMode, ScenarioContext.Current["AttendanceMode"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

    }
 }