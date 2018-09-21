using Dfc.FindACourse.Common.Models;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseSearchCriteria
    {
        string SubjectKeyword { get; set; }
        string TownOrPostcode { get; set; }
        int? Distance { get; set; }
        List<QualLevel> QualificationLevels { get; set; }
        List<StudyModeExt> StudyModes { get; set; }
        List<string> AttendanceModes { get; set; }
        List<AttendancePattern> AttendancePatterns { get; set; }
        bool? IsDfe1619Funded { get; set; }
    }
}