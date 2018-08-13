using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class Opportunity : IOpportunity
    {
        public int Id { get; }
        public StudyMode StudyMode { get; }
        public AttendanceMode AttendanceMode { get; }
        public AttendancePattern AttendancePattern { get; }
        public bool IsDfe1619Funded { get; }
        public DateTime? StartDate { get; }
        public IVenue Venue { get; }
        public IDuration Duration { get; }

        public Opportunity(
            int id,
            StudyMode studyMode,
            AttendanceMode attendanceMode,
            AttendancePattern attendancePattern,
            bool isDfe1619Funded,
            DateTime? startDate,
            IVenue venue,
            IDuration duration)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (!Enum.IsDefined(typeof(StudyMode), studyMode))
                throw new ArgumentOutOfRangeException(nameof(studyMode));
            if (!Enum.IsDefined(typeof(AttendanceMode), attendanceMode))
                throw new ArgumentOutOfRangeException(nameof(attendanceMode));
            if (!Enum.IsDefined(typeof(AttendancePattern), attendancePattern))
                throw new ArgumentOutOfRangeException(nameof(attendancePattern));
            if (venue == null)
                throw new ArgumentNullException(nameof(venue));
            if (duration == null)
                throw new ArgumentNullException(nameof(duration));

            Id = id;
            StudyMode = studyMode;
            AttendanceMode = attendanceMode;
            AttendancePattern = attendancePattern;
            IsDfe1619Funded = isDfe1619Funded;
            StartDate = startDate;
            Venue = venue;
            Duration = duration;
        }
    }
}
