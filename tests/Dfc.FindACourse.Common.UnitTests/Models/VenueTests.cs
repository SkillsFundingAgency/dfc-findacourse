using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class VenueTests
    {
        [Fact]
        public void Constructor_WithNameAsNull_ThrowsArgumentException()
        {
            // arrange
            string name = null;
            var address = new Mock<IAddress>();

            // act & assert
            Assert.Throws<ArgumentException>(() => new Venue(name, address.Object));
        }

        [Fact]
        public void Constructor_WithNameAsEmptyString_ThrowsArgumentException()
        {
            // arrange
            var name = string.Empty;
            var address = new Mock<IAddress>();

            // act & assert
            Assert.Throws<ArgumentException>(() => new Venue(name, address.Object));
        }

        [Fact]
        public void Constructor_WithNameAsWhiteSpace_ThrowsArgumentException()
        {
            // arrange
            var name = " ";
            var address = new Mock<IAddress>();

            // act & assert
            Assert.Throws<ArgumentException>(() => new Venue(name, address.Object));
        }

        [Fact]
        public void Constructor_WithAddressAsNull_ThrowsArgumentNullException()
        {
            // arrange
            var name = "Name";
            IAddress address = null;

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new Venue(name, address));
        }

        [Fact]
        public void Constructor_WithDistanceAsNull_AssignsNull()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = null;

            // act
            var actual = new Venue(name, address.Object, distance);

            // assert
            Assert.Null(actual.Distance);
        }

        [Fact]
        public void Constructor_WithDistanceLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = -0.1;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Venue(name, address.Object, distance));
        }

        [Fact]
        public void Constructor_WithDistanceAsZero_AssignsProperty()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = 0;

            // act
            var actual = new Venue(name, address.Object, distance);

            // assert
            Assert.Equal(distance, actual.Distance);
        }

        [Fact]
        public void Constructor_WithDistanceGreaterThanZero_AssignsProperty()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = 0.1;

            // act
            var actual = new Venue(name, address.Object, distance);

            // assert
            Assert.Equal(distance, actual.Distance);
        }

        [Fact]
        public void Constructor_WithRequiredArgumentsOnly_AssignsProperties()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();

            // act
            var actual = new Venue(name, address.Object);

            // assert
            Assert.Equal(name, actual.Name);
            Assert.NotNull(actual.Address);
        }

        [Fact]
        public void Constructor_WithRequiredAndNoneRequiredArguments_AssignsProperties()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = 0.1;

            // act
            var actual = new Venue(name, address.Object, distance);

            // assert
            Assert.Equal(name, actual.Name);
            Assert.NotNull(actual.Address);
            Assert.Equal(distance, actual.Distance);
        }

        [Fact]
        public void Equals_ShouldBeEqual()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = 0.1;
            
            var a = new Venue(name, address.Object, distance);
            var b = new Venue(name, address.Object, distance);

            // act & assert
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldNotBeEqual()
        {
            // arrange
            var name = "Name";
            var address = new Mock<IAddress>();
            double? distance = 0.1;

            var a = new Venue(name, address.Object, distance);
            var b = new Venue($"{name} X", address.Object, distance);

            // act & assert
            Assert.False(a.Equals(b));
        }
    }
}
