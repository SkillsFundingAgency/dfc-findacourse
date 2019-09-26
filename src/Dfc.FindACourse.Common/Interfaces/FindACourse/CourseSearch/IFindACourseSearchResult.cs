using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Common.Models.FindACourse;
using System;
using System.Collections.Generic;


namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IFindACourseSearchResult
    {
        //int NoOfPages { get; }
        //int NoOfRecords { get; }
        //int PageNo { get; }
        //IEnumerable<IFindACourseItemDetail> Items { get; }

        string ODataContext { get; set; }
        int? ODataCount { get; set; }
        dynamic SearchFacets { get; set; } //FACSearchFacets SearchFacets { get; set; }

        int? PageNo { get; set; }
        int? NoOfPages { get; set; }
        IEnumerable<FindACourseSearchItem> Value { get; set; }
    }
}
