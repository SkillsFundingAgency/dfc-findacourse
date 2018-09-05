using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum AttendanceMode
    {
        [Display(Name = "Not Known")]
        NotKnown = 0,
        [Display(Name = "Classroom-based")]
        LocationCampus = 1,
        [Display(Name = "Face To Face")]
        FaceToFace = 2,
        [Display(Name = "Work based")]
        WorkBased = 3,
        [Display(Name = "Mixed Mode")]
        MixedMode = 4,
        [Display(Name = "Online/Distance Learning")]
        DistanceWithAttendance = 5,
        [Display(Name = "Online/Distance Learning")]
        DistanceWithoutAttendence = 6,
        [Display(Name = "Online/Distance Learning")]
        OnlineWithAttendance = 7,
        [Display(Name = "Online/Distance Learning")]
        OnlineWithoutAttendence = 8
    }
}