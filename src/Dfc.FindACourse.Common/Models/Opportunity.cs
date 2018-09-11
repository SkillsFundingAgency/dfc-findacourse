using Dfc.FindACourse.Common.Interfaces;
using System;

namespace Dfc.FindACourse.Common.Models
{
    public class Opportunity : IOpportunity
    {
        private static readonly string _defaultRegion = "UNITED KINGDOM";

        public int Id { get; }
        public StudyMode StudyMode { get; }
        public AttendanceMode AttendanceMode { get; }
        public AttendancePattern AttendancePattern { get; }
        public bool IsDfe1619Funded { get; }
        public IDescriptionDate StartDate { get; }
        public IVenue Venue { get; }
        public bool HasVenue => Venue != null;
        public string Region { get; }
        public bool HasRegion => !string.IsNullOrWhiteSpace(Region);
        public IDuration Duration { get; }

        public Opportunity(
            int id,
            StudyMode studyMode,
            AttendanceMode attendanceMode,
            AttendancePattern attendancePattern,
            bool isDfe1619Funded,
            IDescriptionDate startDate,
            IVenue venue,
            string region,
            IDuration duration)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (!Enum.IsDefined(typeof(StudyMode), studyMode))
                throw new ArgumentOutOfRangeException(nameof(studyMode));
            if (!Enum.IsDefined(typeof(AttendanceMode), attendanceMode))
                throw new ArgumentOutOfRangeException(nameof(attendanceMode));
            if (!Enum.IsDefined(typeof(AttendancePattern), attendancePattern))
                throw new ArgumentOutOfRangeException(nameof(attendancePattern));
            Id = id;
            StudyMode = studyMode;
            AttendanceMode = attendanceMode;
            AttendancePattern = attendancePattern;
            IsDfe1619Funded = isDfe1619Funded;
            StartDate = startDate ?? throw new ArgumentNullException(nameof(startDate));
            Venue = venue;
            Region = (venue == null && string.IsNullOrWhiteSpace(region)) ? _defaultRegion.ToSentenceCase() : region.ToSentenceCase();
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
        }
    }
}