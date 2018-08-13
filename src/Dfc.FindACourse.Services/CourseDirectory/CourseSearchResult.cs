using Dfc.FindACourse.Services.CourseDirectory.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseSearchResult : ICourseSearchResult
    {
        public int NoOfPages { get; }
        public int NoOfRecords { get; }
        public int PageNo { get; }
        public IEnumerable<ICourseItem> Items { get; }

        public CourseSearchResult(
            int noOfPages,
            int noOfRecords,
            int pageNo,
            IEnumerable<ICourseItem> items)
        {
            if (noOfPages < 0)
                throw new ArgumentOutOfRangeException(nameof(noOfPages));
            if (noOfRecords < 0)
                throw new ArgumentOutOfRangeException(nameof(noOfRecords));
            if (pageNo < 0)
                throw new ArgumentOutOfRangeException(nameof(pageNo));
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            NoOfPages = noOfPages;
            NoOfRecords = noOfRecords;
            PageNo = pageNo;
            Items = items;
        }
    }
}