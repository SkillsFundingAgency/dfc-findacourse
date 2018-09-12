using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Enums;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using System;
using System.Linq;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public static class CourseDirectoryExtensions
    {
        public static SortType ToSortType(this SortBy sortBy)
        {
            switch (sortBy)
            {
                case SortBy.Relevance: return SortType.A;
                case SortBy.Distance: return SortType.D;
                case SortBy.StartDate: return SortType.S;
                default: return SortType.A;
            }
        }

        public static QualificationLevel ToQualificationLevel(this string qualificationLevel)
        {
            switch (qualificationLevel)
            {
                case "Entry Level": return QualificationLevel.EntryLevel;
                case "Level 1": return QualificationLevel.Level1;
                case "Level 2": return QualificationLevel.Level2;
                case "Level 3": return QualificationLevel.Level3;
                case "Level 4": return QualificationLevel.Level4;
                case "Level 5": return QualificationLevel.Level5;
                case "Level 6": return QualificationLevel.Level6;
                case "Level 7": return QualificationLevel.Level7;
                case "Level 8": return QualificationLevel.Level8;
                default: return QualificationLevel.LevelNa;
            }
        }

        public static StudyMode ToStudyMode(this string studyMode)
        {
            switch (studyMode)
            {
                case "Full time": return StudyMode.FullTime;
                case "Part time": return StudyMode.PartTime;
                case "Part of a full-time program": return StudyMode.PartTimeOfAFullTimeProgram;
                case "Flexible": return StudyMode.Flexible;
                case "Not known": return StudyMode.NotKnown;
                default: return StudyMode.NotKnown;
            }
        }

        public static AttendanceMode ToAttendanceMode(this string attendenceMode)
        {
            switch (attendenceMode)
            {
                case "Location / campus": return AttendanceMode.LocationCampus;
                case "Face-to-face (non-campus)": return AttendanceMode.FaceToFace;
                case "Work-based": return AttendanceMode.WorkBased;
                case "Mixed Mode": return AttendanceMode.MixedMode;
                case "Distance with attendance": return AttendanceMode.DistanceWithAttendance;
                case "Distance without attendance": return AttendanceMode.DistanceWithoutAttendence;
                case "Online with attendance": return AttendanceMode.OnlineWithAttendance;
                case "Online without attendance": return AttendanceMode.OnlineWithoutAttendence;
                default: return AttendanceMode.NotKnown;
            }
        }

        public static AttendancePattern ToAttendancePattern(this string attendencePattern)
        {
            switch (attendencePattern)
            {
                case "Daytime/working hours": return AttendancePattern.DaytimeWorkHours;
                case "Day/Block release": return AttendancePattern.DayBlockRelease;
                case "Evening": return AttendancePattern.Evening;
                case "Twilight": return AttendancePattern.Twilight;
                case "Weekend": return AttendancePattern.Weekend;
                case "Customised": return AttendancePattern.Customised;
                case "Not applicable": return AttendancePattern.NotApplicable;
                default: return AttendancePattern.NotKnown;
            }
        }

        public static Address ToAddess(this AddressType addressType)
        {
            double latitude = double.TryParse(addressType.Latitude, out latitude) ? latitude : 0;
            double longitude = double.TryParse(addressType.Longitude, out longitude) ? longitude : 0;

            return new Address(
                addressType.Address_line_1,
                addressType.Address_line_2,
                addressType.Town,
                addressType.County,
                addressType.PostCode,
                latitude,
                longitude);
        }

        public static Venue ToVenue(this VenueInfo venueInfo)
        {
            double? distance = venueInfo.DistanceSpecified ? venueInfo.Distance : default(double?);

            return new Venue(
                venueInfo.VenueName,
                venueInfo.VenueAddress.ToAddess(),
                distance);
        }

        public static Course ToCourse(this CourseInfo courseInfo)
        {
            int id = int.TryParse(courseInfo.CourseID, out id) ? id : 0;

            return new Course(
                id,
                courseInfo.CourseTitle,
                courseInfo.QualificationLevel.ToQualificationLevel());
        }
        public static CourseDetails ToCourseDetail(this CourseDetail courseDetail)
        {
            int id = int.TryParse(courseDetail.CourseID, out id) ? id : 0;
           
            return new CourseDetails(id,
             courseDetail.CourseTitle, 
             courseDetail.CourseSummary,
             courseDetail.AwardingBody,
             courseDetail.EntryRequirements,
             courseDetail.AssessmentMethod= string.Empty,
             courseDetail.EquipmentRequired,
             courseDetail.URL,
             courseDetail.BookingURL,
             courseDetail.TariffRequired,
             courseDetail.LADID,
             courseDetail.QualificationReferenceAuthority,
             courseDetail.QualificationReference,
             courseDetail.QualificationTitle,
             courseDetail.Level2EntitlementCategoryDesc,
             courseDetail.Level3EntitlementCategoryDesc,
             courseDetail.SectorLeadBodyDesc,
             courseDetail.AccreditationStartDate,
             courseDetail.AccreditationEndDate,
             courseDetail.CertificationEndDate,
             courseDetail.CreditValue,
             courseDetail.QCAGuidedLearningHours,
             courseDetail.SkillsForLifeTypeDesc
                );
        }
        public static Duration ToDuration(this DurationType durationType)
        {
            double value = double.TryParse(durationType.DurationValue, out value) ? value : 0;

            if (value > 0
                && !string.IsNullOrWhiteSpace(durationType.DurationUnit)
                && !string.IsNullOrWhiteSpace(durationType.DurationDescription))
            {
                return new Duration(value, durationType.DurationUnit, durationType.DurationDescription);
            }

            if (value > 0 && !string.IsNullOrWhiteSpace(durationType.DurationUnit))
            {
                return new Duration(value, durationType.DurationUnit);
            }

            if (!string.IsNullOrWhiteSpace(durationType.DurationDescription))
            {
                return new Duration(durationType.DurationDescription);
            }

            return Duration.Default;
        }

        public static DescriptionDate ToDescriptionDate(this StartDateType startDateType)
        {
            DateTime? startDate = DateTime.TryParse(startDateType.Item, out DateTime dt) ? dt : default(DateTime?);

            if (startDate.HasValue && startDateType.ItemElementName == ItemChoiceType.Date)
            {
                return new DescriptionDate(startDate.Value);
            }

            if (!string.IsNullOrWhiteSpace(startDateType.Item) && startDateType.ItemElementName == ItemChoiceType.DateDesc)
            {
                return new DescriptionDate(startDateType.Item);
            }

            return DescriptionDate.Default;
        }

        public static ApplicationAcceptedThroughoutYear ToAppAcceptedThroughout(this OpportunityDetailApplicationAcceptedThroughoutYear oppDetAppAccThroughoutYear)
        {
            if (oppDetAppAccThroughoutYear == OpportunityDetailApplicationAcceptedThroughoutYear.Y)
                return ApplicationAcceptedThroughoutYear.Y;
            else
                return ApplicationAcceptedThroughoutYear.N;
        }
        private static ItemChoice[] ToItemsChoice(this ItemsChoiceType[] itemChoiceTypes)
        {
            return itemChoiceTypes.Cast<ItemChoice>().ToArray();

        }

        public static Opportunity ToOpportunity(this OpportunityInfo opportunityInfo)
        {
            int id = int.TryParse(opportunityInfo.OpportunityId, out id) ? id : 0;

            Venue venue = null;
            string region = null;
            
            try
            {
                venue = ((VenueInfo)opportunityInfo.Item).ToVenue();
            }
            catch (InvalidCastException)
            {
                try
                {
                    region = opportunityInfo.Item.ToString();
                }
                catch (InvalidCastException)
                {
                    // Unbale to cast to a Venue or a Region
                }
            }

            return new Opportunity(
                id,
                opportunityInfo.StudyMode.ToStudyMode(),
                opportunityInfo.AttendanceMode.ToAttendanceMode(),
                opportunityInfo.AttendancePattern.ToAttendancePattern(),
                opportunityInfo.DFE1619Funded,
                opportunityInfo.StartDate.ToDescriptionDate(),
                venue,
                region,
                opportunityInfo.Duration.ToDuration());
        }
        public static Opportunity ToOpportunity(this OpportunityDetail opportunityDetail)
        {
            int id = int.TryParse(opportunityDetail.OpportunityId, out id) ? id : 0;

            Venue venue = null;
            string region = null;

            //try
            //{
            //    venue = ((VenueInfo)opportunityDetail.Item).ToVenue();
            //}
            //catch (InvalidCastException)
            //{
            //    try
            //    {
            //        region = opportunityInfo.Item.ToString();
            //    }
            //    catch (InvalidCastException)
            //    {
            //        // Unbale to cast to a Venue or a Region
            //    }
            //}

            return new Opportunity(
                id,
                opportunityDetail.StudyMode.ToStudyMode(),
                opportunityDetail.AttendanceMode.ToAttendanceMode(),
                opportunityDetail.AttendancePattern.ToAttendancePattern(),
                false, //NOT Set in oppinfo
                opportunityDetail.StartDate.ToDescriptionDate(),
                venue,
                region,
                opportunityDetail.Duration.ToDuration(), 
                //OppDetails
                opportunityDetail.Price,
                opportunityDetail.PriceDesc,
                opportunityDetail.EndDate,
                opportunityDetail.Timetable,
                opportunityDetail.LanguageOfAssessment,
                opportunityDetail.LanguageOfInstruction,
                opportunityDetail.PlacesAvailable,
                opportunityDetail.EnquireTo,
                opportunityDetail.ApplyTo,
                opportunityDetail.ApplyFromDate,
                opportunityDetail.ApplyUntilDate,
                opportunityDetail.ApplyUntilDesc,
                opportunityDetail.URL,
                opportunityDetail.A10,
                opportunityDetail.Items,
                opportunityDetail.ItemsElementName.ToItemsChoice(),
                opportunityDetail.ApplicationAcceptedThroughoutYear.ToAppAcceptedThroughout(),
                opportunityDetail.ApplicationAcceptedThroughoutYearSpecified

                );
        }
       
        public static Provider ToProvider(this ProviderInfo providerInfo)
        {
            try
            { 
            int id = int.TryParse(providerInfo.ProviderID, out id) ? id : 0;
            Provider provider = new Provider(id, providerInfo.ProviderName);
            provider.UKPRN = providerInfo.UKPRN;
            provider.UPIN = providerInfo.UPIN;
            provider.TFPlusLoans = providerInfo.TFPlusLoans;
            provider.TFPlusLoansSpecified = providerInfo.TFPlusLoansSpecified;
            provider.DFE1619Funded = providerInfo.DFE1619Funded;
            provider.DFE1619FundedSpecified = providerInfo.DFE1619FundedSpecified;
            provider.FEChoices_LearnerDestination = providerInfo.FEChoices_LearnerDestination;
            provider.FEChoices_LearnerDestinationSpecified = providerInfo.FEChoices_LearnerDestinationSpecified;
            provider.FEChoices_LearnerSatisfaction = providerInfo.FEChoices_LearnerSatisfaction;
            provider.FEChoices_LearnerSatisfactionSpecified = providerInfo.FEChoices_LearnerSatisfactionSpecified;
            provider.FEChoices_EmployerSatisfaction = providerInfo.FEChoices_EmployerSatisfaction;
            provider.FEChoices_EmployerSatisfactionSpecified = providerInfo.FEChoices_EmployerSatisfactionSpecified;
            //provider.Website = providerInfo.Website;
            //provider.Email = providerInfo.Email;
            //provider.Phone = providerInfo.Phone;
            //provider.UKPRN = providerInfo.Fax;
            //provider.UKPRN = providerInfo.UKPRN;


            return provider;
            }
            catch
            {
                return new Provider (1, "test");
            }
        }
        public static Provider ToProvider(this ProviderDetail providerDetail)
        {
            try
            {
                int id = int.TryParse(providerDetail.ProviderID, out id) ? id : 0;
                Provider provider = new Provider(id, providerDetail.ProviderName);
                provider.UKPRN = providerDetail.UKPRN;
                provider.UPIN = providerDetail.UPIN;
                provider.TFPlusLoans = providerDetail.TFPlusLoans;
                provider.TFPlusLoansSpecified = providerDetail.TFPlusLoansSpecified;
                provider.DFE1619Funded = providerDetail.DFE1619Funded;
                provider.DFE1619FundedSpecified = providerDetail.DFE1619FundedSpecified;
                provider.FEChoices_LearnerDestination = providerDetail.FEChoices_LearnerDestination;
                provider.FEChoices_LearnerDestinationSpecified = providerDetail.FEChoices_LearnerDestinationSpecified;
                provider.FEChoices_LearnerSatisfaction = providerDetail.FEChoices_LearnerSatisfaction;
                provider.FEChoices_LearnerSatisfactionSpecified = providerDetail.FEChoices_LearnerSatisfactionSpecified;
                provider.FEChoices_EmployerSatisfaction = providerDetail.FEChoices_EmployerSatisfaction;
                provider.FEChoices_EmployerSatisfactionSpecified = providerDetail.FEChoices_EmployerSatisfactionSpecified;
                provider.Website = providerDetail.Website;
                provider.Email = providerDetail.Email;
                provider.Phone = providerDetail.Phone;
                provider.UKPRN = providerDetail.Fax;
                provider.UKPRN = providerDetail.UKPRN;


                return provider;
            }
            catch
            {
                return new Provider(1, "test");
            }
        }
        public static Venue ToVenueInfo(this VenueDetail venue)
        {
            string name = venue.VenueName;
            IAddress address = venue.VenueAddress.ToAddess();
            double? distance = 0.0f;

            return new Venue(name, address, distance);
        }
    }
}