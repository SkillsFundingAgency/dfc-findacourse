namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface IAddress
    {
        string Line1 { get; }
        string Line2 { get; }
        string Town { get; }
        string County { get; }
        string Postcode { get; }
        double Latitude { get; }
        double Longitude { get; }
    }
}