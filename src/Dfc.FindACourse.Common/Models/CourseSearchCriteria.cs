using Dfc.FindACourse.Common.Interfaces;
using System;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseSearchCriteria : ICourseSearchCriteria
    {
        public string SubjectKeyword { get; set; }
        public string TownOrPostcode { get; set; }
        public int? Distance { get; set; }
        public QualificationLevel[] QualificationLevels { get; set; }
        public StudyMode[] StudyModes { get; set; }
        public AttendanceMode[] AttendanceModes { get; set; }
        public AttendancePattern[] AttendancePatterns { get; set; }
        public bool? IsDfe1619Funded { get; set; }

        public CourseSearchCriteria(string subjectKeyword)
        {
            if (string.IsNullOrWhiteSpace(subjectKeyword))
                throw new ArgumentException($"{nameof(subjectKeyword)} cannot be null, empty or only whitespace.");

            SubjectKeyword = subjectKeyword;

            QualificationLevels = new QualificationLevel[] { };
            StudyModes = new StudyMode[] { };
            AttendanceModes = new AttendanceMode[] { };
            AttendancePatterns = new AttendancePattern[] { };
        }
    }
}