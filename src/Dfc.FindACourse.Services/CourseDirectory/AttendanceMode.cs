using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public enum AttendanceMode
    {
        NotKnown = 0,
        LocationCampus = 1,
        FaceToFace = 2,
        WorkBased = 3,
        MixedMode = 4,
        DistanceWithAttendance = 5,
        DistanceWithoutAttendence  = 6,
        OnlineWithAttendance = 7,
        OnlineWithoutAttendence = 8
    }
}
