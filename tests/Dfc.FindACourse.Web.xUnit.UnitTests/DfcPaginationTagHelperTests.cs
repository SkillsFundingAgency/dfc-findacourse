using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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
            Helper = new DfcPaginationTagHelper();

           /* var fieldInfo = Helper.GetType().GetField();
          //  var text = enumValue.ToString();

            if (fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes && descriptionAttributes.Length > 0)

    */
        }

        [Fact]
        public void TestProcess()
        {
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

        }

    }

}
