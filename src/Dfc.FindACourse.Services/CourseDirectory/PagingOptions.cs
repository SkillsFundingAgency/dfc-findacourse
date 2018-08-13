using Dfc.FindACourse.Services.CourseDirectory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class PagingOptions : IPagingOptions
    {
        public SortBy SortBy { get; }
        public int PageNo { get; }

        public PagingOptions(SortBy sortBy, int pageNo)
        {
            if (!Enum.IsDefined(typeof(SortBy), sortBy))
                throw new ArgumentOutOfRangeException(nameof(sortBy));
            if (pageNo < 0)
                throw new ArgumentOutOfRangeException(nameof(pageNo));

            SortBy = SortBy;
            PageNo = pageNo;
        }
    }
}
