using System;
using System.Collections.Generic;
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
using Moq;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class ControllerTests : BaseTests
    {
        public CourseDirectoryController Controller { get; private set; }

        public ControllerTests()
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
                MockCourseDirectoryHelper.Object,
                MockPostcodeService.Object
            );
            
            Assert.NotNull(Controller.Configuration);
            Assert.NotNull(Controller.Service);
            Assert.NotNull(Controller.Cache);
            Assert.NotNull(Controller.Telemetry);
            Assert.NotNull(Controller.Settings);
            Assert.NotNull(Controller.Files);
            Assert.NotNull(Controller.CourseDirectory);
            Assert.NotNull(Controller.CourseDirectoryHelper);
            Assert.NotNull(Controller.PostcodeService);
        }


        // Tests the Starting View.
        [Fact]
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
            Assert.NotNull(result);
        }

        [Fact]
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
            Assert.True(result != null);
            Assert.True(result.Count == 7);
            Assert.True(result[0] == "ANIMAL");
            Assert.True(result[1] == "ANIMAL BEHAVIOR");
            Assert.True(result[2] == "ANIMAL CARE");
            Assert.True(result[3] == "ANIMAL KEEPER");
            Assert.True(result[4] == "BAKER");
            Assert.True(result[5] == "BAKER ASSISTANT");
            Assert.True(result[6] == "BAKER CLEANER");
        }

        [Fact]
        public void TestAutocompleteNoInput()
        {
            var json = Controller.Autocomplete(null) as JsonResult;

            Assert.Null(json.Value);
        }


        [Fact]
        public void TestCourseDetailsInvalidModelState()
        {
            Controller.ModelState.AddModelError("test", "test");
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            var result = Controller.CourseDetails(5, "0") as ViewResult;
            MockTelemetryClient.Verify();
            AssertDefaultView(result);
        }
        [Fact]
        public void TestOpportunityDetailsInvalidModelState()
        {
            Controller.ModelState.AddModelError("test", "test");
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            var result = Controller.OpportunityDetails(5, "0", 6) as ViewResult;
            MockTelemetryClient.Verify();
            AssertDefaultView(result);
        }
        [Fact]
        public void TestCourseDetailsResultWithValidModelState()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int?>(), It.IsAny<int?>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()
            )).Returns(true);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var expected = new CourseDetailViewModel(courseDetailsResult.Value, "0");

            var result = Controller.CourseDetails(5, "0") as ViewResult;

            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Exactly(1)));
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            expected.IsSame(result.Model);
            Assert.Null(result.ContentType);
            Assert.Null(result.StatusCode);
            Assert.Null(result.TempData);
            Assert.Null(result.ViewEngine);
            Assert.Null(result.ViewName);
            Assert.True(result.ViewData.Count == 0);
        }
        [Fact]
        public void TestOpportunityDetailsResultWithValidModelState()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int>(), It.IsAny<int>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()
            )).Returns(true);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var expected = new CourseDetailViewModel(courseDetailsResult.Value, "0");

            var result = Controller.OpportunityDetails(5, "0", 6) as ViewResult;

            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Exactly(1)));
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            expected.IsSame(result.Model);
            Assert.Null(result.ContentType);
            Assert.Null(result.StatusCode);
            Assert.Null(result.TempData);
            Assert.Null(result.ViewEngine);
            Assert.NotNull(result.ViewName);
            Assert.True(result.ViewData.Count == 0);
        }

        [Fact]
        public void TestCourseDetailsResultWithValidModelStateAndInvalidSearchResult()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int>(), It.IsAny<int>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<DateTime>()
            )).Returns(false);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var result = Controller.CourseDetails(5, "0") as ViewResult;
            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Never()));
            AssertDefaultErrorView(result);
        }
        [Fact]
        public void TestOpportunityDetailsResultWithValidModelStateAndInvalidSearchResult()
        {
            var courseDetailsResult = CreateCourseDetailsResult();

            MockCourseDirectoryService.Setup(x => x.CourseItemDetail(It.IsAny<int>(), It.IsAny<int>())).Returns(courseDetailsResult);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseItemDetail>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<DateTime>()
            )).Returns(false);
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();

            var result = Controller.OpportunityDetails(5, "0", 6) as ViewResult;
            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Never()));
            AssertDefaultErrorView(result);
        }
        private static Result<CourseItemDetail> CreateCourseDetailsResult()
        {
            var descriptionDate = new DescriptionDate(DateTime.Now);
            var venue = new Venue("v", new Address("L1", "L2", "L3", "L4", "L5", 10, 10), 10);
            var course = new CourseDetails(1, "test", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
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
            var listOpps = new List<IOpportunity>
            {
                opportunity
            };
            var provider = new Provider(1, "provider");
            var courseItem = new CourseItemDetail(course, listOpps, provider, venue);
            var courseDetailsResult = Result.Ok(courseItem);
            return courseDetailsResult;
        }

        //[Fact]
        //public void TestCourseSearchResultInvalidModelState()
        //{
        //    Controller.ModelState.AddModelError("test", "test");
        //    MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

        //    var result = Controller.CourseSearchResult(new CourseSearchRequestModel()) as ViewResult;
        //    MockTelemetryClient.Verify();
        //    AssertDefaultView(result);
        //}

        [Fact]
        public void TestCourseSearchResultWithValidModelState()
        {
            var fromQuery = new CourseSearchRequestModel() { SubjectKeyword = "TestSubjectKeyword", LocationRadius = 10 };
            var criteria = new CourseSearchCriteria("test");
            var courseSearchResult = Result.Ok(new CourseSearchResult(1, 1, 1, new CourseItem[] { }));
            var expected = new CourseSearchResultViewModel(courseSearchResult)
            { SubjectKeyword = fromQuery.SubjectKeyword, Location = fromQuery.Location };


            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            MockTelemetryClient.Setup(x => x.Flush()).Verifiable();
            MockCourseDirectory.Setup(x => x.CreateCourseSearchCriteria(fromQuery)).Returns(criteria);
            MockCourseDirectory.Setup(x => x.IsSuccessfulResult(
                It.IsAny<IResult<CourseSearchResult>>(), It.IsAny<ITelemetryClient>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()
                )).Returns(true);
            MockCourseDirectoryService.Setup(x => x.CourseDirectorySearch(criteria, It.IsAny<PagingOptions>())).Returns(courseSearchResult);

            var result = Controller.CourseSearchResult(fromQuery) as ViewResult;
            MockTelemetryClient.Verify(x=>x.TrackEvent(It.IsAny<string>(), null, null),(Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Exactly(1)));
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            expected.IsSame(result.Model);
            Assert.Null(result.ContentType);
            Assert.Null(result.StatusCode);
            Assert.Null(result.TempData);
            Assert.Null(result.ViewEngine);
            Assert.Null(result.ViewName);
            Assert.True(result.ViewData.Count == 0);
        }

        private void AssertDefaultView(ViewResult result)
        {
            Assert.NotNull(result);
            Assert.Null(result.Model);
            Assert.Null(result.ContentType);
            Assert.Null(result.StatusCode);
            Assert.Null(result.TempData);
            Assert.Null(result.ViewEngine);
            Assert.Null(result.ViewName);
            Assert.True(result.ViewData.Count == 0);
        }
        private void AssertDefaultErrorView(ViewResult result)
        {
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.Null(result.ContentType);
            Assert.Null(result.StatusCode);
            Assert.Null(result.TempData);
            Assert.Null(result.ViewEngine);
            Assert.NotNull(result.ViewName);
            Assert.True(result.ViewData.Count == 0);
        }
        [Fact]
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
            MockCourseDirectoryService.Setup(x => x.CourseDirectorySearch(criteria, It.IsAny<PagingOptions>()))
                .Returns(courseSearchResult);

            var result = Controller.CourseSearchResult(fromQuery) as ViewResult;
            MockTelemetryClient.Verify(x => x.TrackEvent(It.IsAny<string>(), null, null), (Times.Never()));
            MockTelemetryClient.Verify(x => x.Flush(), (Times.Never()));
            AssertDefaultErrorView(result);
        }
    }
}
