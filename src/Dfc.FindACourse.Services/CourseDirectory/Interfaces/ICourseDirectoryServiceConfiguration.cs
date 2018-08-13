namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface ICourseDirectoryServiceConfiguration
    {
        string ApiKey { get; }
        int PerPage { get; }
    }
}