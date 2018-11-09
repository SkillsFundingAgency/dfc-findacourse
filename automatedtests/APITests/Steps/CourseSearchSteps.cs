using APITests.Helpers;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System;
using System.Configuration;

namespace APITests.Steps
{

    [Binding]
    internal class CourseSearchSteps
    {
        private readonly RestHelpers Rest = new RestHelpers();
        private readonly MessageHelper Msg = new MessageHelper();
        private static readonly string LiveCourseSearch = ConfigurationManager.AppSettings["LiveCourseSearch"];
        private static readonly string LiveCourseDetails = ConfigurationManager.AppSettings["LiveCourseDetails"];
        private static readonly string TestCourseSearch = ConfigurationManager.AppSettings["TestCourseSearch"];
        private static readonly string TestCourseDetails = ConfigurationManager.AppSettings["TestCourseDetails"];

        private string queryResult = null;

        [Given(@"I have an endpoint (.*)")]
        public void GivenIHaveAnEndpoint(string restEndpoint)
        {
            switch(restEndpoint)
            {
                case "Live Course Search":
                    Rest.SetEndpoint(LiveCourseSearch);
                    break;
                case "Live Course Details":
                    Rest.SetEndpoint(LiveCourseDetails);
                    break;
                case "Test Course Search":
                    Rest.SetEndpoint(TestCourseSearch);
                    break;
                case "Test Course Details":
                    Rest.SetEndpoint(TestCourseDetails);
                    break;
                default:
                    throw new Exception("Endpoint not recognised");
            }          
        }


        [When(@"I search for course (.*)")]
        public void SearchForCourse(string course)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword="+course);
        }


        [When(@"I search for courses with qaulification level (.*) , (.*)")]
        public void SearchForCourseWithQualification(string course, string level)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&QualificationLevels=" +level);
        }


        [When(@"I search for courses with postcode (.*) , (.*)")]
        public void SearchForCourseWithPostcode(string course, string postcode)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&Location=" + postcode);
        }


        [When(@"I search for courses with distance and postcode (.*) , (.*) , (.*)")]
        public void SearchForCourseWithDistance(string course, string postcode, string distance)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&Location=" + postcode + "&LocationRadius=" + distance);
        }


        [When(@"I search for courses with level and postcode (.*) , (.*), (.*)")]
        public void SearchForCourseWithQualificationAndPostCode(string course, string level, string postcode)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&QualificationLevels=" + level+ "&Location=" + postcode);
        }


        [Then(@"the result contains course (.*)")]
        public void SearchContainsCourse(string course)
        {
            Assert.IsTrue(queryResult.Contains(course));
            int count = Int32.Parse(Msg.CountOccurrencesInString(queryResult, course));
            if (count <= 0)
            {
                throw new Exception("No Results for the Searched Course");
            }
        }


        [Then(@"the result do not contain course (.*)")]
        public void SearchNotContainsCourse(string course)
        {
            Assert.IsTrue(queryResult.Contains(course));
            int count = Int32.Parse(Msg.CountOccurrencesInString(queryResult, course));
            if (count > 0)
            {
                throw new Exception("Unexpected Results returned for the Searched Course");
            }
        }

        [When(@"I search and filter results by Study Mode (.*) , (.*)")]
        public void FilterByStudyMode(string course, string studyMode)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&StudyModes=" + studyMode);
        }


        [When(@"I search and filter results by Attendance Mode (.*) , (.*)")]
        public void FilterByAttendanceMode(string course, string attendancemodeMode)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&AttendanceModes=" + attendancemodeMode);
        }


        [When(@"I search and filter results by Attendance Pattern (.*) , (.*)")]
        public void FilterByAttendancePattern(string course, string attendancemodePattern)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&AttendancePatterns=" + attendancemodePattern);
        }


        [When(@"I search and filter results by Qualification Level (.*) , (.*)")]
        public void FilterByLevel(string course, string level)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&QualificationLevels=" + level);
        }


        [When(@"I search and filter results by DFE Funded (.*) , (.*)")]
        public void FilterByDFEFunded(string course, string dfefunded)
        {
            queryResult = Rest.GetQuery("?SubjectKeyword=" + course + "&IsDfe1619Funded" + dfefunded);
        }


        [When(@"I view course details(.*)")]
        public void ViewCourseDetails(string course)
        {
            queryResult = Rest.GetQuery(course);
        }

    }
}