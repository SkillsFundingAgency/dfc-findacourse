using Dfc.FindACourse.Common.Models;
using System;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class DurationTests
    {
        [Fact]
        public void Constructor_WithValueLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            double value = -1;
            var unit = "some unit";

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Duration(value, unit));
        }

        [Fact]
        public void Constructor_WithUnitAsNull_ThrowsArgumentException()
        {
            // arrange
            double value = 0;
            string unit = null;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Duration(value, unit));
        }

        [Fact]
        public void Constructor_WithUnitAsEmptyString_ThrowsArgumentException()
        {
            // arrange
            double value = 0;
            var unit = string.Empty;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Duration(value, unit));
        }

        [Fact]
        public void Constructor_WithValueAsZeroAndUnitAsNoneEmptyString_AssignsProperties()
        {
            // arrange
            double value = 0;
            var unit = "some unit";

            // act 
            var actual = new Duration(value, unit);

            // assert
            Assert.Equal(value, actual.Value);
            Assert.Equal(unit, actual.Unit);
        }

        [Fact]
        public void Constructor_WithValueAsZeroAndUnitAsNoneEmptyString_ToString()
        {
            // arrange
            double value = 0;
            var unit = "some unit";

            // act 
            var actual = new Duration(value, unit);

            // assert
            Assert.Equal($"{value} {unit}", actual.ToString());
        }

        [Fact]
        public void Constructor_WithValueGreaterThanZeroAndUnitAsNoneEmptyString_ToString()
        {
            // arrange
            double value = 1;
            var unit = "some unit";

            // act 
            var actual = new Duration(value, unit);

            // assert
            Assert.Equal($"{value} {unit}", actual.ToString());
        }

        [Fact]
        public void Equals_ShouldBeEqual()
        {
            // arrange 
            var a = new Duration(1, "some unit");
            var b = new Duration(1, "some unit");

            // act & assert
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldNotBeEqual()
        {
            // arrange 
            var a = new Duration(1, "some unit");
            var b = new Duration(2, "some other unit");

            // act & assert
            Assert.False(a.Equals(b));
        }
    }
}
