namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseItem
    {
        ICourse Course { get; }
        IOpportunity Opportunity { get; }
        IProvider Provider { get; }
    }
}