using Dfc.FindACourse.Common.Models;
using System;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class ProviderTests
    {
        [Fact]
        public void Constructor_WithIdLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var id = -1;
            var name = "some name";

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Provider(id, name));
        }

        [Fact]
        public void Constructor_WithNameAsNull_ThrowsArgumentException()
        {
            // arrange
            var id = 0;
            string name = null;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Provider(id, name));
        }

        [Fact]
        public void Constructor_WithNameAsEmptyString_ThrowsArgumentException()
        {
            // arrange
            var id = 0;
            var name = string.Empty;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Provider(id, name));
        }

        [Fact]
        public void Constructor_WithIdAsZeroAndNameAsNoneEmptyString_AssignsProperties()
        {
            // arrange
            var id = 0;
            var name = "some name";

            // act 
            var actual = new Provider(id, name);

            // assert
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.Name);
        }

        [Fact]
        public void Constructor_WithIdAsGreaterTheZeroAndNameAsNoneEmptyString_AssignsProperties()
        {
            // arrange
            var id = 1;
            var name = "some name";

            // act 
            var actual = new Provider(id, name);

            // assert
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.Name);
        }
    }
}
