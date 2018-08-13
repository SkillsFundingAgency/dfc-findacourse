using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class PagingOptions : IPagingOptions
    {
        public SortBy SortBy { get; }
        public int PageNo { get; }
        public int PerPage { get; }

        public PagingOptions(SortBy sortBy, int pageNo, int perPage)
        {
            if (!Enum.IsDefined(typeof(SortBy), sortBy))
                throw new ArgumentOutOfRangeException(nameof(sortBy));
            if (pageNo < 0)
                throw new ArgumentOutOfRangeException(nameof(pageNo));
            if (perPage < 1)
                throw new ArgumentOutOfRangeException(nameof(perPage));

            SortBy = SortBy;
            PageNo = pageNo;
            PerPage = perPage;
        }
    }
}
