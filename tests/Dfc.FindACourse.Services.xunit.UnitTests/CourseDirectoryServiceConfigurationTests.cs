using System;
using Dfc.FindACourse.Services.CourseDirectory;
using Xunit;

namespace Dfc.FindACourse.Services.xUnit.UnitTests
{
    public class CourseDirectoryServiceConfigurationTests
    {
        [Fact]
        public void TestConstructorGivenNullApiKey()
        {
            string apiKey = null;
            const int perPage = 1;
            const string apiAddress = "test";

            Assert.Throws<ArgumentException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenEmptyApiKey()
        {
            var apiKey = string.Empty;
            const int perPage = 1;
            const string apiAddress = "test";

            Assert.Throws<ArgumentException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenPerPageEqualToZero()
        {
            const string apiKey = "test";
            const int perPage = 0;
            const string apiAddress = "test";

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenPerPageLessThanZero()
        {
            const string apiKey = "test";
            const int perPage = -1;
            const string apiAddress = "test";

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenNullApiAddress()
        {
            const string apiKey = "test";
            const int perPage = 1;
            string apiAddress = null;

            Assert.Throws<ArgumentException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenEmptyApiAddress()
        {
            const string apiKey = "test";
            const int perPage = 1;
            string apiAddress = string.Empty;

            Assert.Throws<ArgumentException>(() =>
                new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress));
        }

        [Fact]
        public void TestConstructorGivenValidParameters()
        {
            const string apiKey = "testApiKey";
            const int perPage = 10;
            const string apiAddress = "testApiAddress";

            var config = new CourseDirectoryServiceConfiguration(apiKey, perPage, apiAddress);
            Assert.True(config.ApiKey == apiKey);
            Assert.True(config.PerPage == perPage);
            Assert.True(config.ApiAddress == apiAddress);
        }

    }
}
