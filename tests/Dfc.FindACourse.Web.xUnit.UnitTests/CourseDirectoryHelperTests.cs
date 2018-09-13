using System.Collections.Generic;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    [TestClass]
    public class CourseDirectoryHelperTests : BaseTests
    {
        public CourseDirectoryHelper Helper { get; private set; }

        public CourseDirectoryHelperTests()
        {
            Helper = new CourseDirectoryHelper();
        }

        // Tests the Starting View.
        [Fact]
        public void TestQualificationLevelsAAAAAA()
        {
            // Arrange
           /* var expected = new List<QualLevel>();
            var request = new CourseSearchRequestModel
            {
                QualificationLevel = "1"
            };

            Helper.QualificationLevels(request, MockFileHelper.Object);
            */

            // Assert
        }

        [Fact]
        public void TestQualificationLevels()
        {
            // Arrange
            var expected = new List<QualLevel>();
            var request = new CourseSearchRequestModel
            {
                QualificationLevel = "1"
            };

            Helper.QualificationLevels(request, MockFileHelper.Object);


            // Assert
        }

        [Fact]
        public void TestGetQualificationLevelGivenNullString()
        {
            string level = null;
            const int expected = -1;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetQualificationLevelGivenEmptyString()
        {
            var level = string.Empty;
            const int expected = -1;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetQualificationLevelGivenValidString()
        {
            var level = "12";
            const int expected = 12;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }
    }
}
