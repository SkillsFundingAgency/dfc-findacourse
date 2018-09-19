using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourseSearch
    {
        SearchCriteriaStructure CreateSearchCriteriaStructure(ICourseSearchCriteria criteria, string apiKey);
        CourseListRequestStructure CreateCourseListRequestStructure(IPagingOptions options, SearchCriteriaStructure searchCriteria, string recordsPerPage);
        CourseSearchResult CreateCourseSearchResult(CourseListResponseStructure response);
    }
}