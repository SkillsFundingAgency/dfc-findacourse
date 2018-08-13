namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourseDirectoryService
    {
        IResult<CourseSearchResult> CourseSearch(ICourseSearchCriteria criteria, IPagingOptions options);
    }
}
