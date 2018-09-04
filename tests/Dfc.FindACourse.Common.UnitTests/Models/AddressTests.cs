using Dfc.FindACourse.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class AddressTests
    {
        [Fact]
        public void Constructor_WithLine1AsNull_ThrowsArgumentException()
        {
            // arrange
            string line1 = null;
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLine1AsEmpty_ThrowsArgumentException()
        {
            // arrange
            string line1 = string.Empty;
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLine1AsWhiteSpace_ThrowsArgumentException()
        {
            // arrange
            string line1 = " ";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithTownAsNull_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            string town = null;
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithTownAsEmpty_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            string town = string.Empty;
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithTownAsWhiteSpace_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            string town = " ";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithPostcodeAsNull_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            string postcode = null;
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithPostcodeAsEmpty_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = string.Empty;
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithPostcodeAsWhiteSpace_ThrowsArgumentException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            string postcode = " ";
            var latitude = 0;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLatitudeLessThanMinus180_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = -180.1;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLatitudeGreaterThan180_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 180.1;
            var longitude = 0;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLongitudeLessThanMinus180_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = -180.1;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithLongitudeGreaterThan180_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 180.1;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude));
        }

        [Fact]
        public void Constructor_WithRequiredArgumentsOnly_AssignsProperties()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line1, actual.Line1);
            Assert.Equal(line2, actual.Line2);
            Assert.Equal(town, actual.Town);
            Assert.Equal(county, actual.County);
            Assert.Equal(postcode, actual.Postcode);
            Assert.Equal(latitude, actual.Latitude);
            Assert.Equal(longitude, actual.Longitude);
        }

        [Fact]
        public void Constructor_WithRequiredAndNoneRequiredArguments_AssignsProperties()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line1, actual.Line1);
            Assert.Equal(line2, actual.Line2);
            Assert.Equal(town, actual.Town);
            Assert.Equal(county, actual.County);
            Assert.Equal(postcode, actual.Postcode);
            Assert.Equal(latitude, actual.Latitude);
            Assert.Equal(longitude, actual.Longitude);
        }

        [Fact]
        public void Constructor_WithLine2AsNull_AssignsNull()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line2, actual.Line2);
        }

        [Fact]
        public void Constructor_WithLine2AsEmptyString_AssignsEmptyString()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = string.Empty;
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line2, actual.Line2);
        }

        [Fact]
        public void Constructor_WithLine2AsWhiteSpace_AssignsWhiteSpace()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = " ";
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line2, actual.Line2);
        }

        [Fact]
        public void Constructor_WithLine2AsNoneEmptyString_AssignsNoneEmptyString()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(line2, actual.Line2);
        }
        
        [Fact]
        public void Constructor_WithCountyAsNull_AssignsNull()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            string county = null;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(county, actual.County);
        }

        [Fact]
        public void Constructor_WithCountyAsEmpty_AssignsEmptyString()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            var county = string.Empty;
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(county, actual.County);
        }

        [Fact]
        public void Constructor_WithCountyAsWhiteSpace_AssignsWhiteSpace()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            var county = " ";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(county, actual.County);
        }

        [Fact]
        public void Constructor_WithCountyAsNoneEmptyString_AssignsNoneEmptyString()
        {
            // arrange
            var line1 = "Line 1";
            string line2 = null;
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            // act 
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal(county, actual.County);
        }

        [Fact]
        public void Equals_ShouldBeEqual()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            var a = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            var b = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // act & assert
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldNotBeEqual()
        {
            // arrange
            var line1 = "Line 1";
            var line2 = "Line 2";
            var town = "Town";
            var county = "County";
            var postcode = "Postcode";
            var latitude = 0;
            var longitude = 0;

            var a = new Address(
                $"{line1} X",
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            var b = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // act & assert
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void ToString_WithAddressPropertiesAsUpperCase_AllPropertiesToSentenceCaseExceptPostcode()
        {
            // arrange
            var line1 = "SOME CENTRE";
            var line2 = "SOME STREET";
            var town = "BIRMINGHAM";
            var county = "WEST MIDLANDS";
            var postcode = "B99 1AB";
            var latitude = 0;
            var longitude = 0;

            // act
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal("Some Centre, Some Street, Birmingham, West Midlands, B99 1AB", actual.ToString());
        }

        [Fact]
        public void ToString_WithAddressPropertiesAsLowerCase_AllPropertiesToSentenceCaseExceptPostcode()
        {
            // arrange
            var line1 = "some centre";
            var line2 = "some street";
            var town = "birmingham";
            var county = "west midlands";
            var postcode = "B99 1AB";
            var latitude = 0;
            var longitude = 0;

            // act
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal("Some Centre, Some Street, Birmingham, West Midlands, B99 1AB", actual.ToString());
        }

        [Fact]
        public void ToString_WithPostcodeAsLowerCase_PostcodeToUpperCase()
        {
            // arrange
            var line1 = "some centre";
            var line2 = "some street";
            var town = "birmingham";
            var county = "west midlands";
            var postcode = "b99 1ab";
            var latitude = 0;
            var longitude = 0;

            // act
            var actual = new Address(
                line1,
                line2,
                town,
                county,
                postcode,
                latitude,
                longitude);

            // assert
            Assert.Equal("Some Centre, Some Street, Birmingham, West Midlands, B99 1AB", actual.ToString());
        }
    }
}
