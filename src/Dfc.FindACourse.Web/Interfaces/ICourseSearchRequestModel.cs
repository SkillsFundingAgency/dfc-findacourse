namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ICourseSearchRequestModel
    {
        string SubjectKeyword { get; set; }
        string Location { get; set; }
        int[] QualificationLevels { get; set; }
        int[] StudyModes { get; set; }
        int[] AttendanceModes { get; set; }
        int[] AttendancePatterns { get; set; }
        bool? IsDfe1619Funded { get; set; }
        string LocationCoordinates { get; set; }
        int LocationRadius { get; set; }
    }
}