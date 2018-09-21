using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dfc.FindACourse.Web.TagHelpers
{
    [HtmlTargetElement("dfc-pagination")]
    public class DfcPaginationTagHelper : TagHelper
    {
        public int DfcPaginationNoOfPages { get; set; }
        public string DfcPaginationUrl { get; set; }
        public string DfcPaginationParamName { get; set; }
        public int DfcPaginationDisplayNoOfPages { get; set; }
        private bool DisplayTag => DfcPaginationDisplayNoOfPages > 0;
        private bool DisplayAsSlidingRange => DfcPaginationDisplayNoOfPages < DfcPaginationNoOfPages;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!DisplayTag) return;

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "pagination");
            var pagination = new DfcPagination(DfcPaginationUrl, DfcPaginationNoOfPages, DfcPaginationDisplayNoOfPages, DfcPaginationParamName, DisplayAsSlidingRange);

            var html = pagination.HtmlPageAnchors();

            output.PostContent.SetHtmlContent(html);
        }

    
    }
}
