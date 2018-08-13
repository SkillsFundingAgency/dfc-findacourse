namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface IPagingOptions
    {
        SortBy SortBy { get; }
        int PageNo { get; }
    }
}