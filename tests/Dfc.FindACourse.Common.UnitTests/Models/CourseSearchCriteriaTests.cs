using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class CourseSearchCriteriaTests
    {
        [Fact]
        public void Constructor_WithSubjectKeywordAsNull_ThrowsArgumentExpection()
        {
            // arrange
            string subjectKeyword = null;

            // act & assert
            Assert.Throws<ArgumentException>(() => new CourseSearchCriteria(subjectKeyword));
        }

        [Fact]
        public void Constructor_WithSubjectKeywordAsEmptyString_ThrowsArgumentExpection()
        {
            // arrange
            var subjectKeyword = string.Empty;

            // act & assert
            Assert.Throws<ArgumentException>(() => new CourseSearchCriteria(subjectKeyword));
        }

        [Fact]
        public void Constructor_WithSubjectKeywordAsWhiteSpace_ThrowsArgumentExpection()
        {
            // arrange
            var subjectKeyword = " ";

            // act & assert
            Assert.Throws<ArgumentException>(() => new CourseSearchCriteria(subjectKeyword));
        }

        [Fact]
        public void Constructor_WithSubjectKeywordAsNoneEmptyString_AssignsProperties()
        {
            // arrange
            var subjectKeyword = "search term";

            // act 
            var actual = new CourseSearchCriteria(subjectKeyword);

            // assert
            Assert.Equal(subjectKeyword, actual.SubjectKeyword);
            Assert.Equal(default(string), actual.TownOrPostcode);
            Assert.Equal(default(int?), actual.Distance);
           // Assert.Equal(new QualificationLevel[] { }, actual.QualificationLevels);
            Assert.Equal(new StudyModeExt[] { }, actual.StudyModes);
            Assert.Equal(new List<string>(), actual.AttendanceModes);
            Assert.Equal(new List<string>(), actual.AttendancePatterns);
            Assert.Equal(default(bool?), actual.IsDfe1619Funded);
        }

        [Fact]
        public void Equals_ShouldBeEqual()
        {
            // arrange
            var subjectKeyword = "search term";

            // act 
            var a = new CourseSearchCriteria(subjectKeyword);
            var b = new CourseSearchCriteria(subjectKeyword);

            // assert
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldNotBeEqual()
        {
            // arrange
            var subjectKeyword = "search term";

            // act 
            var a = new CourseSearchCriteria(subjectKeyword);
            var b = new CourseSearchCriteria($"{subjectKeyword} X");

            // assert
            Assert.False(a.Equals(b));
        }
    }
}
