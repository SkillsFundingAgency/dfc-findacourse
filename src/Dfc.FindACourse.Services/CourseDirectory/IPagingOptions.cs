using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface IPagingOptions
    {
        SortBy SortBy { get; }
        int PageNo { get; }
        int PerPage { get; }
    }
}
