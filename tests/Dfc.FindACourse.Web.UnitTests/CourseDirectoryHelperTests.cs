using System;
using System.Collections.Generic;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.Controllers;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.Services;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dfc.FindACourse.Web.UnitTests
{
    [TestClass]
    public class CourseDirectoryHelperTests : BaseTests
    {
        public CourseDirectoryHelper Helper { get; private set; }

        [TestInitialize]
        public void Init()
        {
            BuildHelper();
        }

        public void BuildHelper()
        {
            Helper = new CourseDirectoryHelper();
        }

        [TestMethod]
        public void TestConstruction()
        {
            BuildHelper();
        }

        // Tests the Starting View.
        [TestMethod]
        public void TestQualificationLevelsAAAAAA()
        {
            // Arrange
           /* var expected = new List<QualLevel>();
            var request = new CourseSearchRequestModel
            {
                QualificationLevel = "1"
            };

            Helper.QualificationLevels(request, MockFileHelper.Object);
            */

            // Assert
        }

        [TestMethod]
        public void TestQualificationLevels()
        {
            // Arrange
            var expected = new List<QualLevel>();
            var request = new CourseSearchRequestModel
            {
                QualificationLevel = "1"
            };

            Helper.QualificationLevels(request, MockFileHelper.Object);


            // Assert
        }

        [TestMethod]
        public void TestGetQualificationLevelGivenNullString()
        {
            string level = null;
            const int expected = -1;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }

        [TestMethod]
        public void TestGetQualificationLevelGivenEmptyString()
        {
            var level = string.Empty;
            const int expected = -1;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }

        [TestMethod]
        public void TestGetQualificationLevelGivenValidString()
        {
            var level = "12";
            const int expected = 12;
            var actual = Helper.GetQualificationLevel(level);

            expected.IsSame(actual);
        }
    }
}
