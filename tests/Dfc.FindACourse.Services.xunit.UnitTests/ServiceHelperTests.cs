using System.Collections.Generic;
using System.Linq;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Tribal;
using Xunit;

namespace Dfc.FindACourse.Services.xUnit.UnitTests
{
    public class ServiceHelperTests
    {
        private IServiceHelper Helper { get; }

        public ServiceHelperTests()
        {
            Helper = new ServiceHelper();
        }

        [Fact]
        public void TestGetQualificationLevelsGivenNullParam()
        {
            var expected = new string[] { };

            var actual = Helper.GetQualificationLevels(null);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetQualificationLevelsGivenEmptyParam()
        {
            var expected = new string[] { };
            var levels = new List<QualLevel>();

            var actual = Helper.GetQualificationLevels(levels);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetQualificationLevelsGivenOneQualificationLevel()
        {
            var expected = new[] { "testLevel" };
            var levels = new List<QualLevel>
            {
                new QualLevel
                {
                    Display = true,
                    Key = "testKey",
                    Level = "testLevel",
                    Text = "testText"
                }
            };

            var actual = Helper.GetQualificationLevels(levels);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetQualificationLevelsGivenMultipleQualificationLevel()
        {
            var expected = new[] { "testLevel1", "testLevel2", "testLevel3" };
            var levels = new List<QualLevel>
            {
                new QualLevel
                {
                    Display = true,
                    Key = "testKey1",
                    Level = "testLevel1",
                    Text = "testText1"
                },
                new QualLevel
                {
                    Display = true,
                    Key = "testKey2",
                    Level = "testLevel2",
                    Text = "testText2"
                },
                new QualLevel
                {
                    Display = true,
                    Key = "testKey3",
                    Level = "testLevel3",
                    Text = "testText3"
                }
            };

            var actual = Helper.GetQualificationLevels(levels);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetTownOrPostcodeGivenNullParam()
        {
            var expected = string.Empty;
            var actual = Helper.GetTownOrPostcode(null);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetTownOrPostcodeGivenEmptyParam()
        {
            var param = string.Empty;
            var expected = string.Empty;
            var actual = Helper.GetTownOrPostcode(param);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetTownOrPostcodeGivenValidParam()
        {
            const string param = "TestPostCode";
            const string expected = "TestPostCode";
            var actual = Helper.GetTownOrPostcode(param);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDistanceGivenNoDistance()
        {
            const float expected = 0;
            var criteria = new CourseSearchCriteria("test")
            {
                Distance = null, TownOrPostcode = "test"
            };
            var actual = Helper.GetDistance(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDistanceGivenADistanceAndNullTownOrPostcode()
        {
            const float expected = 0;
            var criteria = new CourseSearchCriteria("test")
            {
                Distance = 10,
                TownOrPostcode = null
            };
            var actual = Helper.GetDistance(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDistanceGivenADistanceAndEmptyTownOrPostcode()
        {
            const float expected = 0;
            var criteria = new CourseSearchCriteria("test")
            {
                Distance = 10,
                TownOrPostcode = string.Empty
            };
            var actual = Helper.GetDistance(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDistanceGivenADistanceAndATownOrPostcode()
        {
            const float expected = 10;
            var criteria = new CourseSearchCriteria("test")
            {
                Distance = 10,
                TownOrPostcode = "test"
            };
            var actual = Helper.GetDistance(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDfe1619FundedGivenNullValueInCriteria()
        {
            const string expected = "";
            var criteria = new CourseSearchCriteria("test")
                {IsDfe1619Funded = null};
            var actual = Helper.GetDfe1619Funded(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDfe1619FundedGivenFalseValueInCriteria()
        {
            const string expected = "N";
            var criteria = new CourseSearchCriteria("test")
                { IsDfe1619Funded = false };
            var actual = Helper.GetDfe1619Funded(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetDfe1619FundedGivenTrueValueInCriteria()
        {
            const string expected = "Y";
            var criteria = new CourseSearchCriteria("test")
                { IsDfe1619Funded = true };
            var actual = Helper.GetDfe1619Funded(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetStudyModesGivenNullStudyModesInCriteria()
        {
            var expected = new string[] { };
            var criteria = new CourseSearchCriteria("test")
                { StudyModes = null };
            var actual = Helper.GetStudyModes(criteria);
            expected.IsSame(actual);
        }
        [Fact]
        public void TestGetStudyModesGivenNoStudyModesInCriteria()
        {
            //var expected = new string[] { };
            ////var criteria = new CourseSearchCriteria("test")
            ////    { StudyModes = new List<StudyModeExt>() };
            //var actual = Helper.GetStudyModes(criteria);
            //expected.IsSame(actual);
        }

        [Fact]
        public void TestGetStudyModesGivenOneStudyModesInCriteria()
        {
            //var expected = new[] { "test1" };
            ////var criteria = new CourseSearchCriteria("test")
            ////    { StudyModes = new List<StudyModeExt>
            ////    {
            ////        new StudyModeExt{Key = 1, Value = "test1"}
            ////    } };
            ////var actual = Helper.GetStudyModes(criteria);
            //expected.IsSame(actual);
        }

        [Fact]
        public void TestGetStudyModesGivenMultipleStudyModesInCriteria()
        {
            //var expected = new[] { "test1", "test2", "test3" };
            //var criteria = new CourseSearchCriteria("test")
            //{
            //    StudyModes = new List<StudyModeExt>
            //    {
            //        new StudyModeExt{Key = 1, Value = "test1"},
            //        new StudyModeExt{Key = 1, Value = "test2"},
            //        new StudyModeExt{Key = 1, Value = "test3"}
            //    }
            //};
            //var actual = Helper.GetStudyModes(criteria);
            //expected.IsSame(actual);
        }

        [Fact]
        public void TestIsDistanceSpecifiedGivenNullDistance()
        {
            const bool expected = false;
            var criteria = new CourseSearchCriteria("test")
                { Distance = null };
            var actual = Helper.IsDistanceSpecified(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestIsDistanceSpecifiedGivenDistanceEqualToZero()
        {
            const bool expected = false;
            var criteria = new CourseSearchCriteria("test")
                { Distance = 0 };
            var actual = Helper.IsDistanceSpecified(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestIsDistanceSpecifiedGivenDistanceGreaterThanZero()
        {
            const bool expected = true;
            var criteria = new CourseSearchCriteria("test")
                { Distance = 1 };
            var actual = Helper.IsDistanceSpecified(criteria);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestCourseItemsGivenNullResponse()
        {
            var expected = new List<CourseItem>();
            var actual = Helper.CourseItems(null);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestCourseItemsGivenNullCourseDetails()
        {
            var expected = new List<CourseItem>();
            var response = new CourseListResponseStructure
            {
                CourseDetails = null
            };
            var actual = Helper.CourseItems(response);
            expected.IsSame(actual);
        }

        [Fact]
        public void TestCourseItemsGivenNoCourseDetails()
        {
            var expected = new List<CourseItem>();
            var response = new CourseListResponseStructure
            {
                CourseDetails = new CourseStructure[] {}
            };
            var actual = Helper.CourseItems(response);
            expected.IsSame(actual);
        }

       /* [Fact]
        public void TestCourseItemsGivenOneCourseDetails()
        {
            var expected = new List<CourseItem>();
            var course = new CourseStructure
            {
                Course = new CourseInfo {CourseID = "1", CourseTitle = "Title1", QualificationLevel = "Level 1"},
            };
            var response = new CourseListResponseStructure
            {
                CourseDetails = new CourseStructure[] { course }
            };
            var actual = Helper.CourseItems(response).ToList();
            expected.IsSame(actual);
        }*/
        
    }
}
