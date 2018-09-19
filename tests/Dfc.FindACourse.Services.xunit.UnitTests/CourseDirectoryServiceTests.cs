using System;
using System.Threading.Tasks;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Moq;
using Tribal;
using Xunit;

namespace Dfc.FindACourse.Services.xUnit.UnitTests
{
    public class CourseDirectoryServiceTests
    {
        private CourseDirectoryService Service;

        private Mock<ICourseDirectoryServiceConfiguration> _configMock;
        public Mock<ICourseDirectoryServiceConfiguration> MockConfiguration
        {
            get
            {
                if (_configMock != null) return _configMock;

                var mock = new Mock<ICourseDirectoryServiceConfiguration>();
                mock.Setup(x => x.ApiAddress)
                    .Returns("https://apitest.coursedirectoryproviderportal.org.uk/CourseSearchService.svc");
                mock.Setup(x => x.ApiKey).Returns("247962c3-5d72-4581-9840-19c6b6bb638c");
                mock.Setup(x => x.PerPage).Returns(10);

                _configMock = mock;
                return _configMock;
            }
        }

        private Mock<ICourseSearch> _courseSearchMock;
        public Mock<ICourseSearch> MockCourseSearch
        {
            get
            {
                if (_courseSearchMock != null) return _courseSearchMock;

                var mock = new Mock<ICourseSearch>();

                _courseSearchMock = mock;
                return _courseSearchMock;
            }
        }

        private Mock<ServiceInterface> _serviceClientMock;
        public Mock<ServiceInterface> MockServiceClient
        {
            get
            {
                if (_serviceClientMock != null) return _serviceClientMock;

                var mock = new Mock<ServiceInterface>();

                _serviceClientMock = mock;
                return _serviceClientMock;
            }
        }



        public CourseDirectoryServiceTests()
        {
            Service = new CourseDirectoryService(MockConfiguration.Object, MockCourseSearch.Object, MockServiceClient.Object);
        }

        [Fact]
        public void TestConstruction()
        {
            Assert.NotNull(Service.Configuration);
        }

        [Fact]
        public void TestCourseDirectorySearchGivenNullCriteria()
        {
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);

            Assert.Throws<ArgumentNullException>(() => Service.CourseDirectorySearch(null, pagingOptions));
        }

        [Fact]
        public void TestCourseDirectorySearchGivenNullPagingOptions()
        {
            var criteria = new CourseSearchCriteria("test");

            Assert.Throws<ArgumentNullException>(() => Service.CourseDirectorySearch(criteria, null));
        }

        [Fact]
        public void TestCourseDirectorySearchExceptionHandler()
        {
            var criteria = new CourseSearchCriteria("test");
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);

            MockCourseSearch.Setup(x => x.CreateSearchCriteriaStructure(It.IsAny<CourseSearchCriteria>(), It.IsAny<string>())).Throws(new Exception("test"));

            var expected = Result.Fail<CourseSearchResult>("test");

            var actual = Service.CourseDirectorySearch(criteria, pagingOptions);

            expected.IsSame(actual);

        }

        [Fact]
        public void TestCourseDirectorySearch()
        {
            var criteria = new CourseSearchCriteria("test");
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);

            MockCourseSearch.Setup(x =>
                    x.CreateSearchCriteriaStructure(It.IsAny<CourseSearchCriteria>(), It.IsAny<string>()))
                .Returns(new SearchCriteriaStructure());

            MockCourseSearch.Setup(x =>
                x.CreateCourseListRequestStructure(It.IsAny<IPagingOptions>(), It.IsAny<SearchCriteriaStructure>(),
                    It.IsAny<string>())).Returns(new CourseListRequestStructure());

            var courseListOutput = new CourseListOutput();
            MockServiceClient.Setup(x =>
                    x.CourseListAsync(It.IsAny<CourseListInput>()))
                .Returns(Task.FromResult(courseListOutput));

            var list = new CourseSearchResult(1, 1, 1, new[] {new CourseItem()});
            var expected = Result.Ok(list);

            MockCourseSearch.Setup(x =>
                    x.CreateCourseSearchResult(It.IsAny<CourseListResponseStructure>()))
                .Returns(list);

            var actual = Service.CourseDirectorySearch(criteria, pagingOptions);

            expected.IsSame(actual);

        }

        //ASB Need to remove these and place in an integrations test project.
        //[Fact]
        public void TestAllSearches()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (var c in alphabet)
            {
                var criteria = new CourseSearchCriteria(c.ToString().ToUpper());

                var pagingOptions = new PagingOptions(SortBy.Relevance, 1);

                //ASB TODO Need to get these from Config.... so it changes per environment.
                var config = new CourseDirectoryServiceConfiguration(
                    "247962c3-5d72-4581-9840-19c6b6bb638c", 1000000000, "https://apitest.coursedirectoryproviderportal.org.uk/CourseSearchService.svc");
                var courseSearch = new CourseSearch(new ServiceHelper());
                var client = new ServiceInterfaceClient(new ServiceInterfaceClient.EndpointConfiguration(), config.ApiAddress);

                var service = new CourseDirectoryService(config, courseSearch, client);

                service.CourseDirectorySearch(criteria, pagingOptions);
            }


           
        }


        
    }
}
