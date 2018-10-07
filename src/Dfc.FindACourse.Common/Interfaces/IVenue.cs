namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IVenue
    {
        string VenueId { get; }
        string Name { get; }
        IAddress Address { get; }
        string Website { get; }
        double? Distance { get; }
    }
}