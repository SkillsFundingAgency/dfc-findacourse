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


    }
}
