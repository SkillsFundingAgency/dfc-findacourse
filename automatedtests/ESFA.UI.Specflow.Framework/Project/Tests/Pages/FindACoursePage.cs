using System;
using System.Collections.Generic;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class FindACoursePage : BasePage
    {
        private static readonly String PAGE_TITLE = "Find a course";

        public FindACoursePage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private readonly By courseName = By.Name("SubjectKeyword");
        private readonly By courseList = By.CssSelector("#course-list");
        private readonly By qualificationLevel = By.Name("QualificationLevels");
		private readonly By location = By.Name("Location");
		private readonly By distance = By.Name("LocationRadius");
		private readonly By searchBtn = By.Name("Search");
		private readonly By advisorLnk = By.LinkText("Contact an adviser");
        private readonly By postcodeValidation = By.XPath(".//*[@id='FindACourseForm']/div[3]/span");

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

        internal FindACoursePage QualificationDefaultValue(String expectedTxt)
        {
            PageInteractionHelper.VerifyDropdownDefaultValue(qualificationLevel, expectedTxt);
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

        internal FindACoursePage SelectCourse(String courseTxt)
        {
            IList<IWebElement> all = webDriver.FindElements(courseList);
            FormCompletionHelper.SelectFromDropDownList(all, courseTxt,courseList);
            return new FindACoursePage(webDriver);
        }

        internal FindACoursePage CheckCourseList(String autopopulateList)
        {
            IList<IWebElement> all = webDriver.FindElements(courseList);
            FormCompletionHelper.CheckDropDownOptions(all, autopopulateList);
            return new FindACoursePage(webDriver);
        }

        internal FindACoursePage PostCodeValidation()
        {
            FormCompletionHelper.IsElementDisplayed(postcodeValidation);
            return new FindACoursePage(webDriver);
        }
    }
}