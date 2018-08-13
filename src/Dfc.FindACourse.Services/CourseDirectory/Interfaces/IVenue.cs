namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface IVenue
    {
        string Name { get; }
        IAddress Address { get; }
        double? Distance { get; }
    }
}