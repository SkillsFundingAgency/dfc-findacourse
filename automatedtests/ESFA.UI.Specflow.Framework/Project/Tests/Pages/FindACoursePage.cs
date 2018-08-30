using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class FindACoursePage : BasePage
    {
        private static String PAGE_TITLE = "Find a course";

        public FindACoursePage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By courseName = By.Name("SubjectKeyword");
        private By courseList = By.CssSelector("#course-list");
        private By qualificationLevel = By.Name("QualificationLevel");
		private By location = By.Name("Location");
		private By distance = By.Name("LocationRadius");
		private By searchBtn = By.Name("Search");
		private By advisorLnk = By.LinkText("Contact an adviser");

		internal FindACoursePage EnterCourseName(String courseTxt)
		{
            FormCompletionHelper.EnterText(courseName, courseTxt);
            return new FindACoursePage(webDriver);
        }

        internal FindACoursePage EnterCourseNameWithoutClearing(String courseTxt)
        {
            FormCompletionHelper.EnterTextWithoutClearing(courseName, courseTxt);
            return new FindACoursePage(webDriver);
        }

        internal FindACoursePage SelectQualification (String qualification)
		{
			IWebElement element = webDriver.FindElement(qualificationLevel);
			FormCompletionHelper.SelectFromDropDownByText(element,qualification);
			return new FindACoursePage(webDriver);
		}

		internal FindACoursePage EnterLocation(String locationTxt)
		{
			FormCompletionHelper.EnterText(location, locationTxt);
			return new FindACoursePage(webDriver);
		}

		internal FindACoursePage SelectDistance(String distanceTxt)
		{
			IWebElement element = webDriver.FindElement(distance);
			FormCompletionHelper.SelectFromDropDownByText(element, distanceTxt);
			return new FindACoursePage(webDriver);
		}

		internal FindACoursePage ClickSearch()
		{
			FormCompletionHelper.ClickElement(searchBtn);
			return new FindACoursePage(webDriver);
		}

		internal FindACoursePage ClickContactAdvisor(string contactLink)
		{
			FormCompletionHelper.ClickElement(advisorLnk);
			return new FindACoursePage(webDriver);
		}

        //internal FindACoursePage AutopopulateList (string dropdownList)
        //{
        //    //IWebElement element = webDriver.FindElements(courseList);
        //    //FormCompletionHelper.GetDropDownOptions(courseList, dropdownList);
        //    //return new FindACoursePage(webDriver);
        //}
	}
}