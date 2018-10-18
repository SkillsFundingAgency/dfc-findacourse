using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
	[Binding]
	public class CourseDetailsSteps : BaseTest
	{

		[Given(@"I am on the Course Details page")]
		public void NavigateToCourseDetails()
		{
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
        }


        [Then(@"the View Course details page is displayed")]
        public void ViewCourseDetailsPageIsDisplayed()
        {
            Thread.Sleep(2000);
            PageInteractionHelper.WaitForPageToLoad();
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
        }

        [Then(@"course title information is displayed")]
        public void CourseTitleIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetCourseTitle();
        }

        [Then(@"Qualification information (.*) is displayed")]
        public void QualificationInformationIsDisplayed(string qualification)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetQualification(qualification);
        }

        [Then(@"Entry Requirements (.*) are displayed")]
        public void EntryRequirementsAreDisplayed(string entryRequirements)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetEntryRequirements(entryRequirements);
        }

        [Then(@"Cost Details (.*) are displayed")]
        public void ThenCostDetailsAreDisplayed(string cost)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetCost(cost);
        }

        [Then(@"I click the advanced learner link")]
        public void ClickTheAdvancedLearnerLink()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.ClickAdvancedlearnerlink();
        }

        [Then(@"Course Start Date details are displayed")]
        public void CourseStartDateDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetStartDate();
        }

        [Then(@"Course Duration details are displayed")]
        public void CourseDurationDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetDuration();
        }

        [Then(@"Study Mode details are displayed")]
        public void StudyModeDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetStudyMode();
        }

        [Then(@"Attendance Pattern details are displayed")]
        public void AttendancePatternDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetAttendancePattern();
        }

        [Then(@"Attendance Pattern Mode are displayed")]
        public void AttendanceModeDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetAttendanceMode();
        }

        [Then(@"I click on the Google Maps link")]
        public void GoogleMapsLinkDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.ClickGoogleMaps();
        }

        [Then(@"the Provider name is displayed")]
        public void ProviderNameIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetProvider();
        }

        [Then(@"the (.*) Name is displayed")]
        public void VenueOrProviderNameDisplayed(string venue)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetVenueOrProviderName();
        }

        [Then(@"the Venue Address is displayed")]
        public void VenueAddressIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetVenueOrProviderAddress();
        }

        [Then(@"the (.*) Website is displayed")]
        public void VenueWebsiteIsDisplayed(string venue)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetVenueOrProviderWebsite();
        }

        [Then(@"the (.*) Email is displayed")]
        public void VenueEmailIsDisplayed(string venue)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetVenueOrProviderEmail();
        }

        [Then(@"the (.*) Phone Number is displayed")]
        public void VenuePhoneIsDisplayed(string venue)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetVenueOrProviderPhone();
        }

        [Then(@"I click the (.*) Button")]
        public void ThenIClickTheEnrolNowButton(string button)
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.ClickEnrolNow();
        }

        [Then(@"the course description is displayed")]
        public void CourseDescriptionIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetCourseDescription();
        }

        [Then(@"the course equipment is displayed")]
        public void ourseEquipmentIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetCourseEquipment();
        }

        [Then(@"the course assessment is displayed")]
        public void CourseAssessmentIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetCourseAssessment();
        }

        [Then(@"the Provider address is displayed")]
        public void ProviderAddressIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetProviderAddress();
        }

        [Then(@"the Journey Time is displayed")]
        public void JourneyTimeIsDisplayed()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.GetJourneyTime();
        }


        [When(@"I view other courses")]
        public void ViewOtherCourses()
        {
            FindACourseCourseDetailsPage findACourseCourseDetailsPage = new FindACourseCourseDetailsPage(webDriver);
            findACourseCourseDetailsPage.ViewOtherCourses();
        }

    }
}
