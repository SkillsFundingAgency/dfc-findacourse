using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseSearchCriteria
    {
        string SubjectKeyword { get; set; }
        string TownOrPostcode { get; set; }
        int? Distance { get; set; }
        IEnumerable<QualificationLevel> QualificationLevels { get; set; }
        IEnumerable<StudyMode> StudyModes { get; set; }
        IEnumerable<AttendanceMode> AttendanceModes { get; set; }
        IEnumerable<AttendancePattern> AttendancePatterns { get; set; }
        bool? IsDfe1619Funded { get; set; }
    }
}