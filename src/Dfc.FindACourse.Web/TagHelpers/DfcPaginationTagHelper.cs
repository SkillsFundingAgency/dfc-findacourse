using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dfc.FindACourse.Web.TagHelpers
{
    [HtmlTargetElement("dfc-pagination")]
    public class DfcPaginationTagHelper : TagHelper
    {
        public int DfcPaginationNoOfPages { get; set; }
        public string DfcPaginationUrl { get; set; }
        public string DfcPaginationParamName { get; set; }
        public int DfcPaginationDisplayNoOfPages { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "pagination");

            var html = string.Empty;

            if (DfcPaginationDisplayNoOfPages > 0 && DfcPaginationDisplayNoOfPages < DfcPaginationNoOfPages)
            {
                html = HtmlPageAnchors(DfcPaginationUrl, DfcPaginationNoOfPages, DfcPaginationDisplayNoOfPages, DfcPaginationParamName, true);
            }
            else
            {
                html = HtmlPageAnchors(DfcPaginationUrl, DfcPaginationNoOfPages, DfcPaginationDisplayNoOfPages, DfcPaginationParamName);
            }

            output.PostContent.SetHtmlContent(html);
        }

        internal string HtmlPageAnchors(string url, int noOfPages, int displayNoOfPages, string paramName, bool sliding = false)
        {
            var setUrl = string.Empty;
            var currentPageNo = GetAndSetPageNoFromUrl(url, paramName, out setUrl);
            var sb = new StringBuilder();
            var startNumber = 1;
            var displayNumber = displayNoOfPages;

            if (currentPageNo > 1)
            {
                sb.Append(HtmlPreviousAnchor(GetUrlWithPageNo(setUrl, paramName, currentPageNo - 1)));
            }

            if (sliding)
            {
                var ceiling = (int)Math.Ceiling((decimal)displayNumber / 2);

                if (ceiling <= currentPageNo)
                {
                    startNumber = currentPageNo + 1 - ceiling;
                    displayNumber = displayNumber - 1 + startNumber;
                }
            }

            for (var i = startNumber; i <= displayNumber; i++)
            {
                sb.Append(HtmlPageAnchor(GetUrlWithPageNo(setUrl, paramName, i), i, (i == currentPageNo)));
            }

            if (currentPageNo < noOfPages)
                sb.Append(HtmlNextAnchor(GetUrlWithPageNo(setUrl, paramName, currentPageNo + 1)));

            return sb.ToString();
        }

        internal int GetAndSetPageNoFromUrl(string url, string paramName, out string setUrl)
        {
            var ub = new UriBuilder(url);
            var qs = HttpUtility.ParseQueryString(ub.Query);

            int value = string.IsNullOrWhiteSpace(qs[paramName]) ? 1 : int.TryParse(qs[paramName], out value) ? value : 1;

            qs.Set(paramName, value.ToString());
            ub.Query = qs.ToString();
            setUrl = ub.ToString();

            return value;
        }

        internal string GetUrlWithPageNo(string url, string paramName, int pageNo)
        {
            var ub = new UriBuilder(url);
            var qs = HttpUtility.ParseQueryString(ub.Query);

            qs.Set(paramName, pageNo.ToString());
            ub.Query = qs.ToString();

            return ub.ToString();
        }

        internal string HtmlPageAnchor(string url, int pageNo, bool current = false)
        {
            var cssClass = string.Empty;

            if (current)
                cssClass = " current";

            return $"<a href=\"{url}\" class=\"pagination-item{cssClass}\">{pageNo}</a>";
        }

        internal string HtmlPreviousAnchor(string url)
        {
            return $"<a href=\"{url}\" class=\"pagination-item pagination-previous\">Previous</a>";
        }

        internal string HtmlNextAnchor(string url)
        {
            return $"<a href=\"{url}\" class=\"pagination-item pagination-next\">Next</a>";
        }
    }
}
