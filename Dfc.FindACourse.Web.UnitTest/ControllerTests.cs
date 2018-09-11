using System;
using System.Collections.Generic;
using System.Linq;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.Controllers;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Dfc.FindACourse.Web.UnitTest
{
    [TestClass]
    public class ControllerTests : BaseTests
    {
        public CourseDirectoryController Controller { get; private set; }

        [TestInitialize]
        public void Init()
        {
            BuildController();
        }

        public void BuildController()
        {
            Controller = new CourseDirectoryController
            (
                MockConfiguration.Object,
                MockCourseDirectoryService.Object,
                MockMemoryCache.Object,
                MockTelemetryClient.Object,
                MockAppSettings.Object,
                MockCourseDirectory.Object,
                MockFileHelper.Object,
                MockCourseDirectoryHelper.Object
            );
            Assert.IsNotNull(Controller.Configuration, "Configuration");
            Assert.IsNotNull(Controller.Service, "Service");
            Assert.IsNotNull(Controller.Cache, "Cache");
            Assert.IsNotNull(Controller.Telemetry, "Telemetry");
            Assert.IsNotNull(Controller.Settings, "Settings");
            Assert.IsNotNull(Controller.Files, "Settings");
            Assert.IsNotNull(Controller.CourseDirectory);
            Assert.IsNotNull(Controller.CourseDirectoryHelper);
        }

        [TestMethod]
        public void TestConstruction()
        {
            BuildController();
        }

        // Tests the Starting View.
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            MockCourseDirectory.Setup(x => x.GetQualificationLevels()).Returns(new List<SelectListItem>()).Verifiable();
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            // Act
            var result = Controller.Index();

            // Assert
            MockCourseDirectory.Verify();
            MockTelemetryClient.Verify();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAutocomplete()
        {
            //Arrange
            IEnumerable<string> courseNames = new List<string>(
                new[] { "ANIMAL BEHAVIOR", "ANIMAL", "ANIMAL BEHAVIOR",
                    "BAKER", "ANIMAL KEEPER", "BAKER CLEANER", "ANIMAL CARE", "BAKER ASSISTANT" }
             );
            MockCourseDirectory.Setup(x => x.AutoSuggestCourseName(It.IsAny<string>())).Returns(courseNames);

            //Act
            var json = Controller.Autocomplete("TEST") as JsonResult;
            var result = json.Value as List<string>;

            //Assert
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count == 7);
            Assert.IsTrue(result[0] == "ANIMAL");
            Assert.IsTrue(result[1] == "ANIMAL BEHAVIOR");
            Assert.IsTrue(result[2] == "ANIMAL CARE");
            Assert.IsTrue(result[3] == "ANIMAL KEEPER");
            Assert.IsTrue(result[4] == "BAKER");
            Assert.IsTrue(result[5] == "BAKER ASSISTANT");
            Assert.IsTrue(result[6] == "BAKER CLEANER");
        }

        [TestMethod]
        public void TestAutocompleteNoInput()
        {
            var json = Controller.Autocomplete(null) as JsonResult;

            Assert.IsNull(json.Value);
        }


        [TestMethod]
        public void TestCourseDetailsInvalidModelState()
        {
            Controller.ModelState.AddModelError("test", "test");
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            var result = Controller.CourseDetails(5) as ViewResult;
            MockTelemetryClient.Verify();
            AssertDefaultView(result);
        }

        [TestMethod]
        public void TestCourseDetailsResultWithValidModelState()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()
            )).Returns(true);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var expected = new CourseDetailViewModel(courseDetailsResult.Value);

            var result = Controller.CourseDetails(5) as ViewResult;

            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Exactly(1)));
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            expected.IsSame(result.Model);
            Assert.IsNull(result.ContentType);
            Assert.IsNull(result.StatusCode);
            Assert.IsNull(result.TempData);
            Assert.IsNull(result.ViewEngine);
            Assert.IsNull(result.ViewName);
            Assert.IsTrue(result.ViewData.Count == 0);
        }


        [TestMethod]
        public void TestCourseDetailsResultWithValidModelStateAndInvalidSearchResult()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<DateTime>()
            )).Returns(false);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var result = Controller.CourseDetails(5) as ViewResult;
            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Never()));
            AssertDefaultView(result);
        }

        private static Result<CourseItemDetail> CreateCourseDetailsResult()
        {
            var descriptionDate = new DescriptionDate(DateTime.Now);
            var venue = new Venue("v", new Address("L1", "L2", "L3", "L4", "L5", 10, 10), 10);
            var course = new CourseDetails(1, "test", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            var duration = new Duration("desc");
            var opportunity = new Opportunity(
                1,
                StudyMode.Flexible,
                AttendanceMode.DistanceWithoutAttendence,
                AttendancePattern.Customised,
                true, descriptionDate,
                venue,
                "region",
                duration);

            var provider = new Provider(1, "provider");
            var courseItem = new CourseItemDetail(course, opportunity, provider, venue);
            var courseDetailsResult = Result.Ok(courseItem);
            return courseDetailsResult;
        }

        [TestMethod]
        public void TestCourseSearchResultInvalidModelState()
        {
            Controller.ModelState.AddModelError("test", "test");
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            var result = Controller.CourseSearchResult(new CourseSearchRequestModel()) as ViewResult;
            MockTelemetryClient.Verify();
            AssertDefaultView(result);
        }

        [TestMethod]
        public void TestCourseSearchResultWithValidModelState()
        {
            var fromQuery = new CourseSearchRequestModel() { SubjectKeyword = "TestSubjectKeyword", LocationRadius = 20 };
            var criteria = new CourseSearchCriteria("test");
            var courseSearchResult = Result.Ok(new CourseSearchResult(1, 1, 1, new CourseItem[] { }));
            var expected = new CourseSearchResultViewModel(courseSearchResult)
            { SubjectKeyword = fromQuery.SubjectKeyword, Location = fromQuery.Location };


            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();
            MockCourseDirectory.Setup(x => x.CreateCourseSearchCriteria(fromQuery)).Returns(criteria);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult<CourseSearchResult>(
                It.IsAny<IResult<CourseSearchResult>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()
                )).Returns(true);
            MockCourseDirectoryService.Setup(x => x.CourseSearch(criteria, It.IsAny<PagingOptions>())).Returns(courseSearchResult);

            var result = Controller.CourseSearchResult(fromQuery) as ViewResult;
            MockTelemetryClient.Verify(x=>x.TrackEvent(It.IsAny<string>(), null, null),(Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Exactly(1)));
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            expected.IsSame(result.Model);
            Assert.IsNull(result.ContentType);
            Assert.IsNull(result.StatusCode);
            Assert.IsNull(result.TempData);
            Assert.IsNull(result.ViewEngine);
            Assert.IsNull(result.ViewName);
            Assert.IsTrue(result.ViewData.Count == 0);
        }

        private void AssertDefaultView(ViewResult result)
        {
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
            Assert.IsNull(result.ContentType);
            Assert.IsNull(result.StatusCode);
            Assert.IsNull(result.TempData);
            Assert.IsNull(result.ViewEngine);
            Assert.IsNull(result.ViewName);
            Assert.IsTrue(result.ViewData.Count == 0);
        }

        [TestMethod]
        public void TestCourseSearchResultWithValidModelStateAndInvalidSearchResult()
        {
            var fromQuery = new CourseSearchRequestModel() { SubjectKeyword = "TestSubjectKeyword", LocationRadius = 20 };
            var criteria = new CourseSearchCriteria("test");
            var courseSearchResult = Result.Ok(new CourseSearchResult(1, 1, 1, new CourseItem[] { }));
            var expected = new CourseSearchResultViewModel(courseSearchResult)
            { SubjectKeyword = fromQuery.SubjectKeyword, Location = fromQuery.Location };

            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();
            MockCourseDirectory.Setup(x => x.CreateCourseSearchCriteria(fromQuery)).Returns(criteria);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseSearchResult>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<DateTime>()
            )).Returns(false); // Mock that Is Invalid Search Result
            MockCourseDirectoryService.Setup(x => x.CourseSearch(criteria, It.IsAny<PagingOptions>()))
                .Returns(courseSearchResult);

            var result = Controller.CourseSearchResult(fromQuery) as ViewResult;
            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Never()));
            AssertDefaultView(result);
        }
    }
}
