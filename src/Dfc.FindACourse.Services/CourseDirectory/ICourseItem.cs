namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourseItem
    {
        ICourse Course { get; }
        IOpportunity Opportunity { get; }
        IProvider Provider { get; }
    }
}