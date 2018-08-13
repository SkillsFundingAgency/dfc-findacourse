namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface ICourse
    {
        int Id { get; }
        string Title { get; }
        QualificationLevel QualificationLevel { get; }
    }
}