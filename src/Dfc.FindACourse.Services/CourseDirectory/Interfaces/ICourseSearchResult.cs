using System.Collections.Generic;

namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface ICourseSearchResult
    {
        int NoOfPages { get; }
        int NoOfRecords { get; }
        int PageNo { get; }
        IEnumerable<ICourseItem> Items { get; }
    }
}