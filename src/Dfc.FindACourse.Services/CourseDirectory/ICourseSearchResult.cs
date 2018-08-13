using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourseSearchResult
    {
        int NoOfPages { get; }
        int NoOfRecords { get; }
        int PageNo { get; }
        IEnumerable<ICourseItem> Items { get; }
    }
}
