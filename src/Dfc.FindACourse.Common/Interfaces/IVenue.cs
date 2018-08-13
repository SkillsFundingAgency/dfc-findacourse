namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IVenue
    {
        string Name { get; }
        IAddress Address { get; }
        double? Distance { get; }
    }
}