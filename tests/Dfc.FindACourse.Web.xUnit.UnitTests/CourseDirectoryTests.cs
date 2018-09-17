using System;
using System.Collections.Generic;
using System.Xml;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class CourseDirectoryTests : BaseTests
    {
        private CourseDirectory CourseDirectory { get; set; }

        public CourseDirectoryTests()
        {
            CourseDirectory = new CourseDirectory(MockFileHelper.Object, MockCourseDirectoryHelper.Object);

            Assert.NotNull(CourseDirectory.FileHelper);
            Assert.NotNull(CourseDirectory.CourseDirectoryHelper);
        }

        [Fact]
        public void TestGetQualificationLevels()
        {
            var list = new List<QualLevel>
            {
                new QualLevel {Display = true, Key = "Key1", Level = "Level1", Text = "Text1"},
                new QualLevel {Display = false, Key = "Key2", Level = "Level2", Text = "Text2"},
                new QualLevel {Display = true, Key = "Key3", Level = "Level3", Text = "Text3"},
            };
            MockFileHelper.Setup(x => x.LoadQualificationLevels()).Returns(list);

            var expected = new List<SelectListItem>
            {
                new SelectListItem {Text = "Text1", Value = "Key1"},
                new SelectListItem {Text = "Text3", Value = "Key3"}
            };

            var actual = CourseDirectory.GetQualificationLevels();
            
            expected.IsSame(actual);

        }

        [Fact]
        public void TestAutoSuggestCourseNameWithMissSpellings()
        {
            var doc = CreateTestSynonymsDoc();
            var expected = new[] {"1", "2", "3", "4"};

            MockFileHelper.Setup(x => x.LoadSynonyms()).Returns(doc);
            MockCourseDirectoryHelper.Setup(x => x.GetMatches(It.IsAny<string>(), It.IsAny<XmlNodeList>()))
                .Returns(new []{ "1", "2" });
            MockCourseDirectoryHelper.Setup(x => x.GetMissSpellings(It.IsAny<string>(), It.IsAny<XmlDocument>(), It.IsAny<XmlNodeList>()))
                .Returns(new[] { "3", "4" });

            var actual = CourseDirectory.AutoSuggestCourseName("ABC");

            expected.IsSame(actual);
        }


        [Fact]
        public void TestAutoSuggestCourseNameWithoutMissSpellings()
        {
            var doc = CreateTestSynonymsDoc();
            var expected = new[] { "1", "2" };

            MockFileHelper.Setup(x => x.LoadSynonyms()).Returns(doc);
            MockCourseDirectoryHelper.Setup(x => x.GetMatches(It.IsAny<string>(), It.IsAny<XmlNodeList>()))
                .Returns(new[] { "1", "2" });
            MockCourseDirectoryHelper.Setup(x => x.GetMissSpellings(It.IsAny<string>(), It.IsAny<XmlDocument>(), It.IsAny<XmlNodeList>()))
                .Returns(new[] { "3", "4" });

            var actual = CourseDirectory.AutoSuggestCourseName("AB");

            expected.IsSame(actual);
        }

        private XmlDocument CreateTestSynonymsDoc()
        {
            var doc = new XmlDocument();
            XmlNode node = doc.CreateElement("test");
            doc.AppendChild(node);
            XmlNode expansionNode = doc.CreateElement("expansion");
            node.AppendChild(expansionNode);

            return doc;
        }

        [Fact]
        public void TestCreateCourseSearchCriteria()
        {
            var requestModel = new CourseSearchRequestModel
            {
                SubjectKeyword = "SubjectKeyword",
                Location = "Location",
                LocationRadius = 20,
                IsDfe1619Funded = true
            };
            var quals = new List<QualLevel>
            {
                new QualLevel {Display = true, Key = "Key1", Text = "Text1", Level = "Level1"},
                new QualLevel {Display = false, Key = "Key2", Text = "Text2", Level = "Level2"}
            };
            var modes = new List<StudyModeExt>
            {
                new StudyModeExt{Key=1, Value="Value1"},
                new StudyModeExt{Key=2, Value="Value2"}
            };
            var expected = new CourseSearchCriteria
            ( 
                "SubjectKeyword",
                quals,
                "Location",
                20,
                true,
                modes
            );

            MockCourseDirectoryHelper.Setup(x => x.StudyModes(It.IsAny<ICourseSearchRequestModel>())).Returns(modes);
            MockCourseDirectoryHelper.Setup(x => x.QualificationLevels(It.IsAny<ICourseSearchRequestModel>())).Returns(quals);

            var actual = CourseDirectory.CreateCourseSearchCriteria(requestModel);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestIsSuccessfulResultPass()
        {
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            const bool expected = true;
            var result = Result.Ok("Pass");

            var actual = CourseDirectory.IsSuccessfulResult(result, MockTelemetryClient.Object, "test", "test", DateTime.Now);
            MockTelemetryClient.Verify();

            Assert.True(actual == expected);
        }

        [Fact]
        public void TestIsSuccessfulResultFail()
        {
            MockTelemetryClient.Setup(x => x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();
            const bool expected = false;
            var result = Result.Fail<CourseSearchResult>("Fail");

            var actual = CourseDirectory.IsSuccessfulResult(result, MockTelemetryClient.Object, "test", "test", DateTime.Now);
            MockTelemetryClient.Verify();

            Assert.True(actual == expected);
        }
    }
}
