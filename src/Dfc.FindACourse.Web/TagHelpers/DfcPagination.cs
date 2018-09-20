﻿using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

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
                var qs = QueryString;

                int value = string.IsNullOrWhiteSpace(qs[ParamName]) ? 1 :
                    int.TryParse(qs[ParamName], out value) ? value : 1;

                return value;
            }
        }

        public UriBuilder Uri => new UriBuilder(Url);

        public NameValueCollection QueryString => HttpUtility.ParseQueryString(Uri.Query);


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
            var uri = Uri;
            var qs = QueryString;

            qs.Set(ParamName, pageNo.ToString());
            uri.Query = qs.ToString();

            return uri.ToString();
        }
    }
}