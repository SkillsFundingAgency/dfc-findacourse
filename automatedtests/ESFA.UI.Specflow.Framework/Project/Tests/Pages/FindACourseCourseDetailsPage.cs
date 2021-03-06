﻿using System;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
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

        //TO DO - TIDY UP
        private readonly By courseDetailsPage = By.TagName("h2");
        private readonly By noResultsErrorMsg = By.XPath(".//*[@id='FindACourseForm']");
        private readonly string errorString = "There are no courses matching that name. Make sure that you've spelled it correctly, or use a broader description of the course.";
        private readonly By courseTitle = By.XPath(".//*[@id='content']/div[2]/div[1]/h1");
        private readonly By qualification = By.XPath(".//*[@id='1']/table/tbody/tr[1]/td[2]");
        private readonly By qualificationLevel = By.XPath(".//*[@id='1']/table/tbody/tr[2]/td[2]");
        private readonly By entryRequirements = By.XPath(".//*[@id='1']/table/tbody/tr[3]/td[2]");
        private readonly By cost = By.XPath(".//*[@id='1']/table/tbody/tr[4]/td[2]");
        private readonly By advancedlink = By.PartialLinkText("Advanced Learner");
        private readonly By startDate = By.XPath(".//*[@id='1']/table/tbody/tr[5]/td[2]");
        private readonly By duration = By.XPath(".//*[@id='1']/table/tbody/tr[6]/td[2]");
        private readonly By studyMode = By.XPath(".//*[@id='1']/table/tbody/tr[7]/td[2]");
        private readonly By attendanceMode = By.XPath(".//*[@id='1']/table/tbody/tr[8]/td[2]");
        private readonly By attendancePattern = By.XPath(".//*[@id='1']/table/tbody/tr[9]/td[2]"); 
        private readonly By maplink = By.PartialLinkText("Google map");
        private readonly By providerName = By.XPath(".//*[@id='6']/aside/p");
        private readonly By venueName = By.XPath(".//*[@id='6']/aside/table[1]/tbody/tr[1]/td[2]");
        private readonly By venueAddress = By.XPath(".//*[@id='6']/aside/table[1]/tbody/tr[2]/td[2]"); 
        private readonly By venueWebsite = By.XPath(".//*[@id='6']/aside/table[3]/tbody/tr[1]/td[2]/a");
        private readonly By venueEmail = By.XPath(".//*[@id='6']/aside/table[3]/tbody/tr[2]/td[2]/a");
        private readonly By venuePhone = By.XPath(".//*[@id='6']/aside/table[3]/tbody/tr[3]/td[2]");
        private readonly By button = By.XPath(".//*[@id='1']/a");
        private readonly By courseDescription = By.XPath(".//*[@id='2']/h2");
        private readonly By equipment = By.XPath(".//*[@id='2']/p[2]");
        private readonly By assessment = By.XPath(".//*[@id='2']/p[4]");
        private readonly By providerAddress = By.XPath(".//*[@id='6']/aside/table[1]/tbody/tr/td[2]");
        private readonly By journeyTime = By.XPath(".//*[@id='JourneyTimesTrigger']");
        private readonly By drivingTime = By.XPath(".//*[@id='JourneyTimes']/table/tr[1]/td[1]");
        private readonly By otherCourses = By.XPath(".//*[@id='6']/aside/details/summary");
        private readonly By firstCourse = By.XPath(".//*[@id='6']/aside/details/div/table/tbody[1]/tr/td[3]/a");

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

        internal FindACourseCourseDetailsPage ClickGoogleMaps()
        {
            FormCompletionHelper.ClickElement(maplink);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetProvider()
        {
            PageInteractionHelper.VerifyText(providerName, ScenarioContext.Current["ProviderName"].ToString());
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetVenueOrProviderName()
        {
            PageInteractionHelper.VerifyElementPresent(venueName);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetVenueOrProviderAddress()
        {
            PageInteractionHelper.VerifyElementPresent(venueAddress);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetProviderAddress()
        {
            PageInteractionHelper.VerifyElementPresent(providerAddress);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetVenueOrProviderWebsite()
        {
            PageInteractionHelper.VerifyElementPresent(venueWebsite);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetVenueOrProviderEmail()
        {
            PageInteractionHelper.VerifyElementPresent(venueEmail);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetVenueOrProviderPhone()
        {
            PageInteractionHelper.VerifyElementPresent(venuePhone);
            return new FindACourseCourseDetailsPage(webDriver);
        }
          
        internal FindACourseCourseDetailsPage ClickEnrolNow()
        {
            FormCompletionHelper.ClickElement(button);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetCourseDescription()
        {
            PageInteractionHelper.IsElementDisplayed(courseDescription);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetCourseEquipment()
        {
            PageInteractionHelper.IsElementDisplayed(equipment);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetCourseAssessment()
        {
            PageInteractionHelper.IsElementDisplayed(assessment);
            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage GetJourneyTime()
        {
            PageInteractionHelper.IsElementDisplayed(journeyTime);
            FormCompletionHelper.ClickElement(journeyTime);
            System.Threading.Thread.Sleep(2000);
            PageInteractionHelper.IsElementDisplayed(drivingTime);

            if (webDriver.FindElement(drivingTime).GetAttribute("innerText") != "Driving")
                {
                throw new Exception("Google Journey Times not displayed");
                }

            return new FindACourseCourseDetailsPage(webDriver);
        }

        internal FindACourseCourseDetailsPage ViewOtherCourses()
        {
            PageInteractionHelper.IsElementDisplayed(otherCourses);
            FormCompletionHelper.ClickElement(otherCourses);
            System.Threading.Thread.Sleep(1000);
            PageInteractionHelper.IsElementDisplayed(firstCourse);
            FormCompletionHelper.ClickElement(firstCourse);
            return new FindACourseCourseDetailsPage(webDriver);
        }

    }

 }