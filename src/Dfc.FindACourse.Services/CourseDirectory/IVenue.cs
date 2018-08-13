namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface IVenue
    {
        string Name { get; }
        IAddress Address { get; }
        double? Distance { get; }
    }
}