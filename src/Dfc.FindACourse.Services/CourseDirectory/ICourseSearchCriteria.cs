using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface ICourseSearchCriteria
    {
        string SubjectKeyword { get; set; }
        string TownOrPostcode { get; set; }
        int? Distance { get; set; }
        QualificationLevel[] QualificationLevels { get; set; }
        StudyMode[] StudyModes { get; set; } 
        AttendanceMode[] AttendanceModes { get; set; }
        AttendancePattern[] AttendancePatterns { get; set; }
        bool? IsDfe1619Funded { get; set; }
    }
}
