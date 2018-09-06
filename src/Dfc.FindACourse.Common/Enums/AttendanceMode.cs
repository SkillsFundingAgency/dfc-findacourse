using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum AttendanceMode
    {
        [Display(Name = "Not known")]
        NotKnown = 0,
        [Display(Name = "Location campus")]
        LocationCampus = 1,
        [Display(Name = "Face to face")]
        FaceToFace = 2,
        [Display(Name = "Work based")]
        WorkBased = 3,
        [Display(Name = "Mixed mode")]
        MixedMode = 4,
        [Display(Name = "Distance with attendance")]
        DistanceWithAttendance = 5,
        [Display(Name = "Distance without attendence")]
        DistanceWithoutAttendence = 6,
        [Display(Name = "Online with attendance")]
        OnlineWithAttendance = 7,
        [Display(Name = "Online without attendence")]
        OnlineWithoutAttendence = 8
    }
}