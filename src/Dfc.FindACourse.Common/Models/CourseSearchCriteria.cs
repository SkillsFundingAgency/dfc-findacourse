using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseSearchCriteria : ValueObject<CourseSearchCriteria>, ICourseSearchCriteria
    {
        public string SubjectKeyword { get; set; }
        public string TownOrPostcode { get; set; }
        public int? Distance { get; set; }
        public List<QualLevel> QualificationLevels { get; set; }
        public IEnumerable<StudyMode> StudyModes { get; set; }
        public IEnumerable<AttendanceMode> AttendanceModes { get; set; }
        public IEnumerable<AttendancePattern> AttendancePatterns { get; set; }
        public bool? IsDfe1619Funded { get; set; }

        public CourseSearchCriteria(string subjectKeyword)
        {
            if (string.IsNullOrWhiteSpace(subjectKeyword))
                throw new ArgumentException($"{nameof(subjectKeyword)} cannot be null, empty or only whitespace.");

            SubjectKeyword = subjectKeyword;

            QualificationLevels = new List<QualLevel>();
            StudyModes = (new List<StudyMode>()).AsEnumerable();
            AttendanceModes = (new List<AttendanceMode>()).AsEnumerable();
            AttendancePatterns = (new List<AttendancePattern>()).AsEnumerable();
        }
        public CourseSearchCriteria(string subjectKeyword, List<QualLevel> qualLevels, string postcode, int radius)
        {
            if (string.IsNullOrWhiteSpace(subjectKeyword))
                throw new ArgumentException($"{nameof(subjectKeyword)} cannot be null, empty or only whitespace.");

            SubjectKeyword = subjectKeyword;
            TownOrPostcode = postcode;
            Distance = radius;
            QualificationLevels = qualLevels;
            StudyModes = (new List<StudyMode>()).AsEnumerable();
            AttendanceModes = (new List<AttendanceMode>()).AsEnumerable();
            AttendancePatterns = (new List<AttendancePattern>()).AsEnumerable();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SubjectKeyword;
            yield return TownOrPostcode;
            yield return Distance;
            yield return QualificationLevels;
            yield return StudyModes;
            yield return AttendanceModes;
            yield return AttendancePatterns;
            yield return IsDfe1619Funded;
        }
    }
}