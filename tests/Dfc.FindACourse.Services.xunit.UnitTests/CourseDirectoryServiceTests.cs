using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tribal;
using Xunit;
using Xunit.Abstractions;
using Assert = Xunit.Assert;

namespace Dfc.FindACourse.Services.xUnit.UnitTests
{
    public class CourseDirectoryServiceTests
    {
        private readonly ITestOutputHelper _output;

        public CourseDirectoryServiceTests(ITestOutputHelper output)
        {
            _output = output;
            Service = new CourseDirectoryService(
                MockConfiguration.Object, 
                MockCourseSearch.Object,
                MockServiceClient.Object,
                MockTelemetryClient.Object);
        }


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

        private Mock<ITelemetryClient> _telemetryClientMock;
        public Mock<ITelemetryClient> MockTelemetryClient
        {
            get
            {
                if (_telemetryClientMock != null) return _telemetryClientMock;

                var mock = new Mock<ITelemetryClient>();
                _telemetryClientMock = mock;
                return _telemetryClientMock;
            }
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
        public void TestAllSearches()
        {
           // var fileStream = new FileStream("CourseTitles.txt", FileMode.Open);
            var config = new CourseDirectoryServiceConfiguration(
                "247962c3-5d72-4581-9840-19c6b6bb638c", 1000000000,
                "https://apitest.coursedirectoryproviderportal.org.uk/CourseSearchService.svc");
            var courseSearch = new CourseSearch(new ServiceHelper());
            var client = new ServiceInterfaceClient(new ServiceInterfaceClient.EndpointConfiguration(), config.ApiAddress);
            var telemetryClient = new TelemetryClientAdapter(new TelemetryClient());
            var pagingOptions = new PagingOptions(SortBy.Relevance, 1);
            var service = new CourseDirectoryService(config, courseSearch, client, telemetryClient);

            _validSearches = new List<string>();
            _InValidSearches = new List<string>();

            _output.WriteLine("Starting the Parallel Searches");
                var lines = File.ReadLines("CourseTitles.txt");
            
                Parallel.ForEach(lines, line =>
                {
                    line = line.Trim();
                    if (line != string.Empty)
                    {
                        ValidateSearchResults(line, service, pagingOptions);
                    }
                });

            _output.WriteLine("Valid Searches:");
            foreach (var v in _validSearches)
            {
                _output.WriteLine(v);
            }

            _output.WriteLine("InValid Searches:");
            foreach (var v in _InValidSearches)
            {
                _output.WriteLine(v);
            }


            /*
            var tasks = new List<Task<bool>>();
            using (var reader = new StreamReader(fileStream))
            {
                while (true)
                {
                    var line = reader.ReadLine()?.Trim();
                    if (line == null){break;}

                    if (line != string.Empty)
                    {
                        tasks.Add(ValidateSearchResults(line, service, pagingOptions));
                    }
                    Debug.WriteLine($"{line}");
                }

                var results = await Task.WhenAll(tasks);
            }
  */
        }

        public List<string> _validSearches = new List<string>();
        public List<string> _InValidSearches = new List<string>();


        private bool ValidateSearchResults(string line, ICourseDirectoryService service,
            IPagingOptions pagingOptions)
        {

            var criteria = new CourseSearchCriteria(line.ToUpper());
           
            try
            {
                var l = service.CourseDirectorySearch(criteria, pagingOptions);
                if( l == null ) _InValidSearches.Add($"{line} : Result object is null");
                else if( l.Value == null ) _InValidSearches.Add($"********** {line} Result.Value Object is Null ?");
                else if( l.Value.Items == null ) _InValidSearches.Add($"********** {line}  Result.Value.Items Object is Null ?");
                try
                {
                    var res = l.Value.Items.ToList();
                    _validSearches.Add($"{res.Count} : {line}");
                }
                catch (Exception e)
                {
                    _InValidSearches.Add($"{line} : Result.Value.Items.ToList Failed : Exception: {e}");
                }
                
            }
            catch (Exception e)
            {
                _InValidSearches.Add($"{line} : Unhandled Exception: {e}");
            }

            return true;
        }

        private async Task<bool> ValidateSearchResultss(string line, ICourseDirectoryService service, IPagingOptions pagingOptions)
        {

            var criteria = new CourseSearchCriteria(line.ToUpper());
            return await Task.Run(() =>
            {
                var l = service.CourseDirectorySearch(criteria, pagingOptions).Value.Items.ToList();
                Debug.WriteLine($"{l.Count} : {line}");
                return true;
            });
           // await Task.WhenAny(service.CourseDirectorySearch(criteria, pagingOptions).Value.Items.ToList());
           // );


            /*

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



            return true;
           */
        }

        private async Task<bool> ValidateResults(IResult<CourseSearchResult> res)
        {
            Parallel.ForEach(res.Value.Items, (x) => { });
            return true;
        }
    }
}
