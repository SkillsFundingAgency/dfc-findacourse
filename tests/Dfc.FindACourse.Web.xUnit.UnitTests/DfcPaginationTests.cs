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
    }
}

     