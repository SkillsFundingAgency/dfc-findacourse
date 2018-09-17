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
    public class DfcPaginationTagHelperTests
    {
        private DfcPaginationTagHelper Helper { get; set; }
        public DfcPaginationTagHelperTests()
        {
            Helper = new DfcPaginationTagHelper
            {
                DfcPaginationDisplayNoOfPages=5,
                DfcPaginationNoOfPages=120,
                DfcPaginationParamName="PageNo",
                DfcPaginationUrl="http://testPagination"
            };

           /* var fieldInfo = Helper.GetType().GetField();
          //  var text = enumValue.ToString();

            if (fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes && descriptionAttributes.Length > 0)

    */
        }

     //   [Fact]
        public void TestProcessGivenDisplayTagIsFalse()
        {
            Helper.DfcPaginationDisplayNoOfPages = 0;
            var expected = string.Empty;

            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("dfc-pagination",
                new TagHelperAttributeList(),
                (result, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetHtmlContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });
            Helper.Process(tagHelperContext, tagHelperOutput);
            expected.IsSame(tagHelperOutput.PostContent.GetContent());

        }

       // [Fact]
        public void TestProcessGivenDisplayTagIsTrue()
        {
            var expected = "<a href=\"http://testpagination:80/?PageNo=1\" class=\"pagination-item current\">1</a><a href=\"http://testpagination:80/?PageNo=2\" class=\"pagination-item\">2</a><a href=\"http://testpagination:80/?PageNo=3\" class=\"pagination-item\">3</a><a href=\"http://testpagination:80/?PageNo=4\" class=\"pagination-item\">4</a><a href=\"http://testpagination:80/?PageNo=5\" class=\"pagination-item\">5</a><a href=\"http://testpagination:80/?PageNo=2\" class=\"pagination-item pagination-next\">Next</a>";
            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("dfc-pagination",
                new TagHelperAttributeList(),
                (result, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetHtmlContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });
            Helper.Process(tagHelperContext, tagHelperOutput);
            expected.IsSame(tagHelperOutput.PostContent.GetContent());
            Assert.True(tagHelperOutput.TagName == "div");
            Assert.True(tagHelperOutput.Attributes[0].Name == "class");
            Assert.True(tagHelperOutput.Attributes[0].Value.ToString() == "pagination");

        }

        [Fact]
        public void d()
        {

        }

    }

}
