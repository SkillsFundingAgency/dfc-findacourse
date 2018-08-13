namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface ICourseDirectoryService
    {
        IResult<CourseSearchResult> CourseSearch(ICourseSearchCriteria criteria, IPagingOptions options);
    }
}