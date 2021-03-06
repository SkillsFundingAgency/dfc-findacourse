﻿using Dfc.FindACourse.Common.Models;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseSearchCriteria
    {
        string SubjectKeyword { get; set; }
        string TownOrPostcode { get; set; }
        int? Distance { get; set; }
        List<string> QualificationLevels { get; set; }
        List<string> StudyModes { get; set; }
        List<string> AttendanceModes { get; set; }
        List<string> AttendancePatterns { get; set; }
        bool? IsDfe1619Funded { get; set; }

        int? TopResults { get; set; }
        int? PageNo { get; set; }
    }
}