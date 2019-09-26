using Dfc.FindACourse.Common.Models;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IFindACourseSearchCriteria
    {
        string SubjectKeyword { get; set; }
        string TownOrPostcode { get; set; }
        int? Distance { get; set; }
        List<QualLevel> QualificationLevels { get; set; }
        List<int> StudyModes { get; set; }
        List<int> AttendanceModes { get; set; }
        List<int> AttendancePatterns { get; set; }
        int? TopResults { get; set; }

        DateTime? StartDate { get; set; }
        int? SortOrder { get; set; }

    }
}
