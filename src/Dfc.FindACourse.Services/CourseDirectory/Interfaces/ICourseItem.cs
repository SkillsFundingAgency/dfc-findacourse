namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface ICourseItem
    {
        ICourse Course { get; }
        IOpportunity Opportunity { get; }
        IProvider Provider { get; }
    }
}