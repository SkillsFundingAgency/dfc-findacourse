using Dfc.FindACourse.Common.Enums;
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

        //OppDetail fields
        public string Price { get; }
        public string PriceDescription { get; }
        public string EndDate { get; }
        public string Timetable { get; }
        public string LanguageOfAssessment { get; }
        public string LanguageOfInstruction { get; }
        public string PlacesAvailable { get; }
        public string EnquireTo { get; }
        public string ApplyTo { get; }
        public string ApplyFrom { get; }
        public string ApplyUntil { get; }
        public string ApplyUntilDescription { get; }
        public string URL { get; }
        public string[] A10 { get; }
        public string[] Items { get; }
        public ItemChoice[] ItemsElementName { get; }
        public ApplicationAcceptedThroughoutYear ApplicationAcceptedThroughoutYear { get; }
        public bool ApplicationAcceptedThroughoutYearSpecified { get; }


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
        public Opportunity(
            int id,
            StudyMode studyMode,
            AttendanceMode attendanceMode,
            AttendancePattern attendancePattern,
            bool isDfe1619Funded,
            IDescriptionDate startDate,
            IVenue venue,
            string region,
            IDuration duration,
            string price,
            string priceDescription,
            string endDate,
            string timetable,
            string langOfAssess,
            string langofIns,
            string places,
            string enquireto,
            string applyto,
            string applyfrom,
            string applyuntil,
            string applyuntildesc,
            string url,
            string[] a10,
            string[] items,
            ItemChoice[] itemsElementName,
            ApplicationAcceptedThroughoutYear applicationAcceptedThroughout,
            bool applicationAcceptedThroughoutSpecified


            )
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
            //OppDetails
            Price = price;
            PriceDescription = priceDescription.ToSentenceCase();
            EndDate = endDate;
            Timetable = timetable;
            LanguageOfAssessment = langOfAssess;
            LanguageOfInstruction = langofIns;
            PlacesAvailable = places;
            EnquireTo = enquireto;
            ApplyTo = applyto;
            ApplyFrom = applyfrom;
            ApplyUntil = applyuntil;
            ApplyUntilDescription = applyuntildesc;
            URL = url;
            A10 = a10;
            Items = items;
            ItemsElementName =  itemsElementName;
            ApplicationAcceptedThroughoutYear = applicationAcceptedThroughout;
            ApplicationAcceptedThroughoutYearSpecified = applicationAcceptedThroughoutSpecified;

        }
    }
}