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
            Assert.Equal("Some Name", actual.Name);
        }

        [Fact]
        public void Constructor_WithIdAsZeroAndNameAsNoneEmptyLowerCaseString_AssignsNameAsSentenceCase()
        {
            // arrange
            var id = 0;
            var name = "some name";

            // act 
            var actual = new Provider(id, name);

            // assert
            Assert.Equal("Some Name", actual.Name);
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
            Assert.Equal("Some Name", actual.Name);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsNullString_ReturnsNullString()
        {
            // arrange
            string name = null;

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal(name, actual);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsEmptyString_ReturnsEmptyString()
        {
            // arrange
            var name = string.Empty;

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal(name, actual);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsWhiteSpaceOnly_ReturnsWhiteSpaceOnly()
        {
            // arrange
            string name = " ";

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal(name, actual);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsUpperCaseStringWithNoSpaces_ReturnsUpperCaseStringWithNoSpaces()
        {
            // arrange
            string name = "ABC";

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal(name, actual);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsUpperCaseStringWithSpaces_ReturnsSentenceCaseString()
        {
            // arrange
            string name = "SOME SCHOOL";

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal("Some School", actual);
        }

        [Fact]
        public void Internal_NameFormatting_WithNameAsLowerCaseStringWithSpaces_ReturnsSentenceCaseString()
        {
            // arrange
            string name = "some school";

            // act 
            var actual = Provider.NameFormatting(name);

            // assert
            Assert.Equal("Some School", actual);
        }
    }
}
