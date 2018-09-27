using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dfc.FindACourse.Web.TagHelpers
{
    public class DfcPagination
    {
        public string Url { get; }
        public int NoOfPages { get; }
        public int DisplayNoOfPages { get; }
        public string ParamName { get; }
        public bool Slide { get; }

        public int CurrentPageNo
        {
            get
            {
                var ub = new UriBuilder(Url);
                var query = QueryHelpers.ParseQuery(ub.Query); //HttpUtility.ParseQueryString(ub.Query);
                var items = query.SelectMany(x => x.Value, (col, val) => new KeyValuePair<string, string>(col.Key, val)).ToList();
                var found = items.Where(x => x.Key == ParamName).ToList();
                var value = 1;

                if (found.Any())
                {
                    value = string.IsNullOrWhiteSpace(found[0].Value) ? 1 : int.TryParse(found[0].Value, out value) ? value : 1;
                }

                return value;
            }
        }

        //public UriBuilder Uri => new UriBuilder(Url);

        //public NameValueCollection QueryString => HttpUtility.ParseQueryString(Uri.Query);


        public DfcPagination(string url, int noOfPages, int displayNoOfPages, string paramName, bool slide)
        {
            Url = url;
            NoOfPages = noOfPages;
            DisplayNoOfPages = displayNoOfPages;
            ParamName = paramName;
            Slide = slide;
        }

        public string HtmlPageAnchors()
        {
            var sb = new StringBuilder();
            sb.Append(PreviousAnchor());
            sb.Append(Anchors(new PageBoundary(Slide, NoOfPages, DisplayNoOfPages, CurrentPageNo)));
            sb.Append(NextAnchor());
            return sb.ToString();
        }

        public string PreviousAnchor()
        {
            var html = string.Empty;

            if (CurrentPageNo <= 1) return html;

            var url = GetUrlWithPageNo(CurrentPageNo - 1);
            html = $"<a href=\"{url}\" class=\"pagination-item pagination-previous\">Previous</a>";

            return html;
        }


        public string Anchors(PageBoundary pageBoundary)
        {
            var sb = new StringBuilder();

            for (var i = pageBoundary.StartNumber; i <= pageBoundary.DisplayNumber; i++)
            {
                var cssClass = string.Empty;
                var url = GetUrlWithPageNo(i);
                var pageNo = i;

                if (i == CurrentPageNo)
                    cssClass = " current";

                sb.Append( $"<a href=\"{url}\" class=\"pagination-item{cssClass}\">{pageNo}</a>");
            }

            return sb.ToString();
        }

        public string NextAnchor()
        {
            var html = string.Empty;

            if (CurrentPageNo >= NoOfPages) return html;

            var url = GetUrlWithPageNo(CurrentPageNo + 1);
            html = $"<a href=\"{url}\" class=\"pagination-item pagination-next\">Next</a>";

            return html;
        }

        public string GetUrlWithPageNo(int pageNo)
        {
            var ub = new UriBuilder(Url);
            var query = QueryHelpers.ParseQuery(ub.Query);
            var items = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
            items.RemoveAll(x => x.Key == ParamName);

            var qb = new QueryBuilder(items);
            qb.Add(ParamName, pageNo.ToString());
            ub.Query = qb.ToQueryString().ToString();

            return ub.ToString();
        }
    }
}