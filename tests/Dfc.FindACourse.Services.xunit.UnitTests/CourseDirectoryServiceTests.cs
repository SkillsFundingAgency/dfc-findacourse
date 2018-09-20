using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web;
using Microsoft.Extensions.Configuration;
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
            Service = new CourseDirectoryService(MockConfiguration.Object, MockCourseSearch.Object,
                MockServiceClient.Object);
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

            MockCourseSearch
                .Setup(x => x.CreateSearchCriteriaStructure(It.IsAny<CourseSearchCriteria>(), It.IsAny<string>()))
                .Throws(new Exception("test"));

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
       // [Fact]
        public async Task TestAllSearches()
        {
            //ASB Need to set these to 
          /*  var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path.Replace("Dfc.FindACourse.Web.UnitTest\\bin\\Debug\\netcoreapp2.1", "src\\Dfc.FindACourse.Web");

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.Development.json", optional: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            var file = new FileHelper(configuration, null, null);*/

           // var file = new FileHelper(configuration, null, null );
          //  var searchTerms = file.LoadSynonyms();
         //   var expansionNodes = searchTerms.GetElementsByTagName("expansion");






            var courselist = new[]
            {
                "Level 3 Plumbing Advanced Apprenticeship"
            }; /*, "certificate","level","english", "maths", "plumbing", "business", "chemistry", "woodwork", "construction", "business", "counselling",
                "health", "esol", "Train maintenance", "Access to HE", "criminology", "social care", "motorcycle", "spanish", "Admin", "Accounting",
                "nursing", "media", "ict", "hairdressing", "councilling", "beauty", "teaching assistant", "law", "teaching", "sport"
                ,"engineering", "mathematics", "music", "science", "biology", "social care", "english GCSE", "SQL", "pe", "security", "childcare", "upholstery"};
                */
            var count = 0;


            await ValidateSearchResults();

            //ASB TODO Need to get these from Config.... so it changes per environment.
/*
            var config = new CourseDirectoryServiceConfiguration(
                "247962c3-5d72-4581-9840-19c6b6bb638c", 1000000000, "https://apitest.coursedirectoryproviderportal.org.uk/CourseSearchService.svc");
            var courseSearch = new CourseSearch(new ServiceHelper());
            var client = new ServiceInterfaceClient(new ServiceInterfaceClient.EndpointConfiguration(), config.ApiAddress);
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);
            var service = new CourseDirectoryService(config, courseSearch, client);

            var tasks = new List<Task<IResult<CourseSearchResult>>>();

            foreach (var c in courselist)
            {
                var criteria = new CourseSearchCriteria(c.ToString().ToUpper());
                var task = Task<IResult<CourseSearchResult>>.Factory.StartNew(() => service.CourseDirectorySearch(criteria, pagingOptions));
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
            Task.WaitAll(tasks.ToArray());

            var tt = new List<Task<List<ICourseItem>>>();
            foreach (var task in tasks)
            {

                foreach (var x in task.Result.Value.Items)
                {

                }
                //var result = task.Result.Value.Items.ToList();
                //var t = Task<List<ICourseItem>>.Factory.StartNew(() => task.Result.Value.Items.ToList());
                //tt.Add(t);
            }

            Task.WaitAll(tt.ToArray());

    */
        }

        private async Task<bool> ValidateSearchResults()
        {
           
            var courselist = new[] {"Level 3 Plumbing Advanced Apprenticeship", "certificate","level","english", "maths", "plumbing", "business", "chemistry", "woodwork", "construction", "business", "counselling",
                "health", "esol", "Train maintenance", "Access to HE", "criminology", "social care", "motorcycle", "spanish", "Admin", "Accounting",
                "nursing", "media", "ict", "hairdressing", "councilling", "beauty", "teaching assistant", "law", "teaching", "sport"
                ,"engineering", "mathematics", "music", "science", "biology", "social care", "english GCSE", "SQL", "pe", "security", "childcare", "upholstery"};

            var config = new CourseDirectoryServiceConfiguration(
                "247962c3-5d72-4581-9840-19c6b6bb638c", 1000000000,
                "https://apitest.coursedirectoryproviderportal.org.uk/CourseSearchService.svc");
            var courseSearch = new CourseSearch(new ServiceHelper());
            var client =
                new ServiceInterfaceClient(new ServiceInterfaceClient.EndpointConfiguration(), config.ApiAddress);
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);
            var service = new CourseDirectoryService(config, courseSearch, client);

            var tasks = new List<Task<List<ICourseItem>>>();

            foreach (var c in courselist)
            {
                var criteria = new CourseSearchCriteria(c.ToString().ToUpper());
                var task = Task<List<ICourseItem>>.Factory.StartNew(() =>
                    service.CourseDirectorySearch(criteria, pagingOptions).Value.Items.ToList()
                    );
                   
                    
                    //( service.CourseDirectorySearch(criteria, pagingOptions).Result.Value.Items.ToList());
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

           /* foreach (var t in tasks)
            {
                await ValidateResults(t.Result);
            }*/

            return true;
        }

        private async Task<bool> ValidateResults(IResult<CourseSearchResult> res)
        {
            Parallel.ForEach(res.Value.Items, (x) => { });
            return true;
        }
    }
}
