using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class DfcPaginationTests
    {
        [Fact]
        public void TestConstructor()
        {
            var actual = new DfcPagination("testUrl", 100, 5, "testParam", true);
            Assert.True(actual.Slide == true);
            Assert.True(actual.Url == "testUrl");
            Assert.True(actual.NoOfPages == 100);
            Assert.True(actual.DisplayNoOfPages == 5);
            Assert.True(actual.ParamName == "testParam");
        }

        [Fact]
        public void TestCurrentPageNoGivenNoPageNoInQueryString()
        {
            var pagination = new DfcPagination("testUrl", 100, 5, "PageNo", true);
            var pageNo = pagination.CurrentPageNo;

            Assert.True(pageNo == 1);
        }

        [Fact]
        public void TestCurrentPageNoGivenPageNoInQueryStringIsEmpty()
        {
            var pagination = new DfcPagination("testUrl/?OtherParam=123&PageNo=&Param=567", 100, 5, "PageNo", true);
            var pageNo = pagination.CurrentPageNo;

            Assert.True(pageNo == 1);
        }

        [Fact]
        public void TestCurrentPageNoGivenPageNoInQueryStringIsTen()
        {
            var pagination = new DfcPagination(
                "testUrl/?OtherParam=123&PageNo=10&Param=567", 100, 5, "PageNo", true);
            var pageNo = pagination.CurrentPageNo;

            Assert.True(pageNo == 10);
        }

        [Fact]
        public void TestGetUrlWithPageNoGivenNoQueryString()
        {
            const string expected = "http://testurl:80/?testParam=155";
            var pagination = new DfcPagination("testUrl", 100, 5, "testParam", true);
            var actual = pagination.GetUrlWithPageNo(155);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestGetUrlWithPageNoGivenExistingQueryStringWithExpectedParam()
        {
            const string expected = "http://testurl:80/?otherParam=567&testParam=155";
            var pagination = new DfcPagination("testUrl/?otherParam=567&testParam=1", 100, 5, "testParam", true);
            var actual = pagination.GetUrlWithPageNo(155);

            expected.IsSame(actual);
        }

        [Fact]
        public void TestPreviousAnchor()
        {
            var expected = "<a href=\"http://testurl:80/?testParam=9\" class=\"pagination-item pagination-previous\">Previous</a>";
            var pagination = new DfcPagination("testUrl/?testParam=10", 100, 5, "testParam", true);
            var actual = pagination.PreviousAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestPreviousAnchorGivenCurrentPageNoEqualToOne()
        {
            var expected = string.Empty;
            var pagination = new DfcPagination("testUrl/?testParam=1", 100, 5, "testParam", true);
            var actual = pagination.PreviousAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestPreviousAnchorGivenCurrentPageNoLessThanOne()
        {
            var expected = string.Empty;
            var pagination = new DfcPagination("testUrl/?testParam=0", 100, 5, "testParam", true);
            var actual = pagination.PreviousAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestNextAnchor()
        {
            var expected = "<a href=\"http://testurl:80/?testParam=11\" class=\"pagination-item pagination-next\">Next</a>";
            var pagination = new DfcPagination("testUrl/?testParam=10", 100, 5, "testParam", true);
            var actual = pagination.NextAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestNextAnchorGivenCurrentPageNoEqualToNoOfPages()
        {
            var expected = string.Empty;
            var pagination = new DfcPagination("testUrl/?testParam=10", 10, 5, "testParam", true);
            var actual = pagination.NextAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestNextAnchorGivenCurrentPageNoGreaterThanNoOfPages()
        {
            var expected = string.Empty;
            var pagination = new DfcPagination("testUrl/?testParam=11", 10, 5, "testParam", true);
            var actual = pagination.NextAnchor();
            expected.IsSame(actual);
        }

        [Fact]
        public void TestAnchorsGivenASlideOfFiveWhenSecondPageIsCurrentPageAndRangeIsOneToFive()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void TestAnchorsGivenASlideOfFiveWhenSecondPageIsCurrentPageAndRangeIsThreeToEight()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void TestAnchorsGivenNoSlideAndThreePagesOnly()
        {
           // throw new NotImplementedException();
        }
    }
}

     