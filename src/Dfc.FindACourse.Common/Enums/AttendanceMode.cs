using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum AttendanceMode
    {
        [Display(Name = "Not Known")]
        NotKnown = 0,
        [Display(Name = "Location Campus")]
        LocationCampus = 1,
        [Display(Name = "Face To Face")]
        FaceToFace = 2,
        [Display(Name = "Work Based")]
        WorkBased = 3,
        [Display(Name = "Mixed Mode")]
        MixedMode = 4,
        [Display(Name = "Distance With Attendance")]
        DistanceWithAttendance = 5,
        [Display(Name = "Distance Without Attendence")]
        DistanceWithoutAttendence = 6,
        [Display(Name = "Online With Attendance")]
        OnlineWithAttendance = 7,
        [Display(Name = "Online Without Attendence")]
        OnlineWithoutAttendence = 8
    }
}