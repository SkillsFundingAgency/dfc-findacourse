namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourse
    {
        int Id { get; }
        string Title { get; }
        QualificationLevel QualificationLevel { get; }
    }
}