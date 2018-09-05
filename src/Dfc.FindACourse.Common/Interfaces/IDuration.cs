namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IDuration
    {
        double Value { get; }
        string Unit { get; }
        string Description { get; }
    }
}