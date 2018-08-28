using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class CourseItemTests
    {
        [Fact]
        public void Constructor_WithCourseAsNull_ThrowArgumentNullException()
        {
            // arrange
            ICourse course = null;
            var opportunity = new Mock<IOpportunity>();
            var provider = new Mock<IProvider>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CourseItem(course, opportunity.Object, provider.Object));
        }

        [Fact]
        public void Constructor_WithOpportunityAsNull_ThrowArgumentNullException()
        {
            // arrange
            var course = new Mock<ICourse>();
            IOpportunity opportunity = null;
            var provider = new Mock<IProvider>();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CourseItem(course.Object, opportunity, provider.Object));
        }

        [Fact]
        public void Constructor_WithProviderAsNull_ThrowArgumentNullException()
        {
            // arrange
            var course = new Mock<ICourse>();
            var opportunity = new Mock<IOpportunity>();
            IProvider provider = null;

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new CourseItem(course.Object, opportunity.Object, provider));
        }

        [Fact]
        public void Constructor_WithNoneNullArguments_AssignsProperties()
        {
            // arrange
            var course = new Mock<ICourse>();
            var opportunity = new Mock<IOpportunity>();
            var provider = new Mock<IProvider>();

            // act
            var actual = new CourseItem(course.Object, opportunity.Object, provider.Object);

            // assert
            Assert.NotNull(actual.Course);
            Assert.NotNull(actual.Opportunity);
            Assert.NotNull(actual.Provider);
        }
    }
}
