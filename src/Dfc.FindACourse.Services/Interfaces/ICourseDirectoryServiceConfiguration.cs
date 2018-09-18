namespace Dfc.FindACourse.Services.Interfaces
{
    public interface ICourseDirectoryServiceConfiguration
    {
        string ApiKey { get; }
        int PerPage { get; }
        string ApiAddress { get; }
    }
}