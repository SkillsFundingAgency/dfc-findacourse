using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface ICourseDirectoryService
    {
        IResult<CourseSearchResult> CourseSearch(ICourseSearchCriteria criteria, IPagingOptions options);
        IResult<CourseItem> CourseDetails(int? courseDetailsId);
    }
}