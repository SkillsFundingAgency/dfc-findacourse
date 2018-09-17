using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.TestUtilities;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.Services;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{

    public class CourseDirectoryHelperTests : BaseTests
    {
        public CourseDirectoryHelper Helper { get; private set; }

        public CourseDirectoryHelperTests()
        {
            Helper = new CourseDirectoryHelper(MockFileHelper.Object);
        }

        [Fact]
        public void TestStudyModesGivenWeHaveCorrectRequestData()
        {
            var expected = new List<StudyModeExt>
            {
                new StudyModeExt{Key = 0, Value="SM0"},
                new StudyModeExt{Key = 1, Value="SM1"},
                new StudyModeExt{Key = 2, Value="SM2"},
                new StudyModeExt{Key = 3, Value="SM3"},
                new StudyModeExt{Key = 4, Value="SM4"},
                new StudyModeExt{Key = 5, Value="SM5"}
            };

            var request = new CourseSearchRequestModel
            {
                StudyModes = new[] {-1, 0, 1, 2, 3, 4, 5, 6}
            };

            var actual = Helper.StudyModes(request);

            expected.IsSame(actual);

        }

        [Fact]
        public void TestStudyModesGivenWeHaveASingleRequestStudyModeThatWontMap()
        {
            var expected = new List<StudyModeExt>();

            var request = new CourseSearchRequestModel
            {
                StudyModes = new []{-1, 6}
            };

            var actual = Helper.StudyModes(request);

            expected.IsSame(actual);

        }

        [Fact]
        public void TestStudyModesGivenWeHaveRequestStudyModeEqualToNull()
        {
            var expected = new List<StudyModeExt>();

            var request = new CourseSearchRequestModel
            {
                StudyModes = null
            };

            var actual = Helper.StudyModes(request);

            expected.IsSame(actual);

        }

        [Fact]
        public void TestStudyModesGivenWeHaveRequestStudyModeEqualEmptyArray()
        {
            var expected = new List<StudyModeExt>();

            var request = new CourseSearchRequestModel
            {
                StudyModes = new int[] {}
            };

            var actual = Helper.StudyModes(request);

            expected.IsSame(actual);
        }
        
        [Fact]
        public void TestHasQualificationLevelsIsTrue()
        {
            const bool expected = true;
            var request = new CourseSearchRequestModel
            {
                QualificationLevels = new[] {1}
            };

            var actual = Helper.HasQualificationLevels(request);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestHasQualificationLevelsIsFalseGivenNull()
        {
            const bool expected = false;
            var request = new CourseSearchRequestModel
            {
                QualificationLevels = null
            };

            var actual = Helper.HasQualificationLevels(request);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestHasQualificationLevelsIsFalseGivenEmpty()
        {
            const bool expected = false;
            var request = new CourseSearchRequestModel
            {
                QualificationLevels = new int[] {}
            };

            var actual = Helper.HasQualificationLevels(request);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestQualificationLevelsGivenNoQualificationLevels()
        {
            var expected = new List<QualLevel>();

            var request = new CourseSearchRequestModel
            {
                QualificationLevels = new int[] { }
            };

            var actual = Helper.QualificationLevels(request);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestQualificationLevelsGivenQualificationLevels()
        {
            var expected = new List<QualLevel>
            {
                new QualLevel {Display = true, Key = "1", Level = "Level1", Text = "Text1"},
                new QualLevel {Display = false, Key = "2", Level = "Level2", Text = "Text2"}
            };
            var request = new CourseSearchRequestModel
            {
                QualificationLevels = new int[] { 1, 2 }
            };
            var levels = new List<QualLevel>
            {
                new QualLevel {Display = false, Key = "0", Level = "Level0", Text = "Text0"},
                new QualLevel {Display = false, Key = "2", Level = "Level2", Text = "Text2"},
                new QualLevel {Display = false, Key = "4", Level = "Level4", Text = "Text4"},
                new QualLevel {Display = true, Key = "1", Level = "Level1", Text = "Text1"}
            };
            MockFileHelper.Setup(x => x.LoadQualificationLevels()).Returns(levels);

            var actual = Helper.QualificationLevels(request);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetMatchesGivenNullExpansionNodes()
        {
            var expected = new List<string>();

            Assert.Throws<ArgumentException>(() => Helper.GetMatches("test", null).ToList());
        }

        [Fact]
        public void TestGetMatchesGivenExpansionNodes()
        {
            var expected = new List<string>
            {
                "A", "B", "C","DE", "DBE", "DACE"
            };

            var doc = new XDocument(new XElement("body",
                new XElement("expansion",
                    new XElement("sub", "A"),
                    new XElement("sub", "B"),
                    new XElement("sub", "C")),
                new XElement("expansion",
                    new XElement("sub", "D"),
                    new XElement("sub", "DB"),
                    new XElement("sub", "DC")),
                new XElement("expansion",
                    new XElement("sub", "DE"),
                    new XElement("sub", "DBE"),
                    new XElement("sub", "DACE")))).ToXmlDocument();

            var actual = Helper.GetMatches("A", doc.GetElementsByTagName("expansion"));

            expected.IsSame(actual);

        }

        private XmlNode CreateExpansionNode(XmlDocument doc, string[] subs)
        {
            var node = doc.CreateElement("expansion");
            doc.AppendChild(node);
            foreach (var s in subs)
            {
                var n = doc.CreateElement("sub");
                n.InnerText = s;
                node.AppendChild(n);
            }

            return node;
        }

        [Fact]
        public void TestGetMissSpellingsGivenNullExpansionNodes()
        {
            Assert.Throws<ArgumentException>(() => Helper.GetMissSpellings("test", new XmlDocument(),  null).ToList());
        }

        [Fact]
        public void TestGetMissSpellingsGivenNullSearchTerms()
        {
            var doc = new XDocument(new XElement("body",
                new XElement("expansion",
                    new XElement("sub", "A"),
                    new XElement("sub", "B"),
                    new XElement("sub", "C")))).ToXmlDocument();
            var list = doc.GetElementsByTagName("expansion");

            Assert.Throws<ArgumentException>(() => Helper.GetMissSpellings("test", null, list ).ToList());
        }

        [Fact]
        public void TestGetMissSpellingsGivenValidInputs()
        {
            var expected = new List<string>
            {
                "A",
                "A", "B", "C","DE", "DBE", "DACE",
                "DE",
                "DE", "DBE", "DACE"
            };

            var doc = new XDocument(new XElement("body",
                new XElement("replacement",
                    new XElement("sub", "A"),
                    new XElement("pat", "A"),
                    new XElement("pat", "B")),
                new XElement("replacement",
                    new XElement("sub", "D"),
                    new XElement("pat", "DB"),
                    new XElement("pat", "DC")),
                new XElement("replacement",
                    new XElement("sub", "DE"),
                    new XElement("pat", "DBE"),
                    new XElement("pat", "DACE")),
                    new XElement("expansion",
                        new XElement("sub", "A"),
                        new XElement("sub", "B"),
                        new XElement("sub", "C")),
                    new XElement("expansion",
                        new XElement("sub", "D"),
                        new XElement("sub", "DB"),
                        new XElement("sub", "DC")),
                    new XElement("expansion",
                        new XElement("sub", "DE"),
                        new XElement("sub", "DBE"),
                        new XElement("sub", "DACE"))
                    )
            ).ToXmlDocument();

            var actual = Helper.GetMissSpellings("A", doc, doc.GetElementsByTagName("expansion"));

            expected.IsSame(actual);
        }

        /*     < replacement >
             < sub > PLUMBING </ sub >
             < pat > PLUMMING </ pat >
             < pat > PLUMING </ pat >
             < pat > PLUMMER </ pat >
             < pat > PLUMPING </ pat >
             < pat > PLUMBIMG </ pat >
             </ replacement >

         foreach (XmlNode replacement in searchTerms.GetElementsByTagName("replacement"))
         {
             foreach (XmlNode pat in replacement.SelectNodes(".//pat"))
             {
                 //if the pat node has the search text return all sub nodes
                 if (pat.InnerText.ToUpper().Contains(search))
                 {
                     foreach (XmlNode replacementSub in replacement.SelectNodes(".//sub"))
                     {
                         yield return replacementSub.InnerText;
                         foreach (var p in GetMatches(replacementSub.InnerText, expansionNodes)) yield return p;

                         // Remember we dont need to test the GetMatches Functionality within this method.
                         var expected = new List<string>
         {
             "A", "B", "C","DE", "DBE", "DACE"
         };

         

 */
        }
    }
