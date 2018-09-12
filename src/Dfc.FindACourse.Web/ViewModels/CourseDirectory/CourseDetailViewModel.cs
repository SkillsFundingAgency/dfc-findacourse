using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseDetailViewModel
    {
        //private CourseDetails value;


        /// <summary>
        /// Main view model constructor
        /// </summary>
        /// <param name="value"></param>
        public CourseDetailViewModel(ICourseItemDetail value, string distance)
        {
            CourseId = value.Coursedetails.CourseId;// Opportunity.Id;   
            CourseTitle = value.Coursedetails.CourseTitle;
            CourseSummary = value.Coursedetails.CourseSummary;
            //QualificationLevel = value.Coursedetails.Le.QualificationLevel;
            StudyMode = value.Opportunity.StudyMode;
            AttendanceMode = value.Opportunity.AttendanceMode;
            AttendencePattern = value.Opportunity.AttendancePattern;
            ProviderName = value.Provider.Name;
            Location = (value.Opportunity.HasVenue) ? value.Opportunity.Venue.Address.ToString() : value.Opportunity.Region;
            Distance = (value.Opportunity.HasVenue && value.Opportunity.Venue.Distance.HasValue) ? value.Opportunity.Venue.Distance.Value.ToString("0.0") : distance;
            StartDate = value.Opportunity.StartDate.ToString();
            Duration = value.Opportunity.Duration.ToString();
            AwardingBody = value.Coursedetails.AwardingBody;
            EntryRequirements = value.Coursedetails.EntryRequirements;
            AssessmentMethod = value.Coursedetails.AssessmentMethod;
            EquipmentRequired = value.Coursedetails.EquipmentRequired;
            URL = value.Coursedetails.URL;
            BookingURL = value.Coursedetails.BookingURL;
            TariffRequired = value.Coursedetails.TariffRequired;
            LADID = value.Coursedetails.LADID;
            QualificationReferenceAuthority = value.Coursedetails.QualificationReferenceAuthority;
            QualificationReference = value.Coursedetails.QualificationReference;
            QualificationTitle = value.Coursedetails.QualificationTitle;
            Level2EntitlementCategoryDesc = value.Coursedetails.Level2EntitlementCategoryDesc;
            Level3EntitlementCategoryDesc = value.Coursedetails.Level3EntitlementCategoryDesc;
            SectorLeadBodyDesc = value.Coursedetails.SectorLeadBodyDesc;
            AccreditationStartDate = value.Coursedetails.AccreditationStartDate;
            AccreditationEndDate = value.Coursedetails.AccreditationEndDate;
            CertificationEndDate = value.Coursedetails.CertificationEndDate;
            CreditValue = value.Coursedetails.CreditValue;
            QCAGuidedLearningHours = value.Coursedetails.QCAGuidedLearningHours;
            SkillsForLifeTypeDesc = value.Coursedetails.SkillsForLifeTypeDesc;
            Venue = (Venue)value.Venue;
            Provider = (Provider)value.Provider;
            Opportunity = (Opportunity)value.Opportunity;


        }

        

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSummary { get; set; }
        public QualificationLevel QualificationLevel { get; set; }
        public StudyMode StudyMode { get; set; }
        public AttendanceMode AttendanceMode { get; set; }
        public AttendancePattern AttendencePattern { get; set; }
        public string ProviderName { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string StartDate { get; set; }
        public string Duration { get; set; }
        public string AwardingBody { get; set; }

        public string EntryRequirements { get; set; }

        public string AssessmentMethod { get; set; }

        public string EquipmentRequired { get; set; }

        public string URL { get; set; }

        public string BookingURL { get; set; }

        public string TariffRequired { get; set; }

        public string LADID { get; set; }

        public string QualificationReferenceAuthority { get; set; }

        public string QualificationReference { get; set; }

        public string QualificationTitle { get; set; }

        public string Level2EntitlementCategoryDesc { get; set; }

        public string Level3EntitlementCategoryDesc { get; set; }

        public string SectorLeadBodyDesc { get; set; }

        public string AccreditationStartDate { get; set; }

        public string AccreditationEndDate { get; set; }

        public string CertificationEndDate { get; set; }

        public string CreditValue { get; set; }

        public string QCAGuidedLearningHours { get; set; }
        public string SkillsForLifeTypeDesc { get; set; }

        public Venue Venue { get; set; }
        public Provider Provider { get; set; }
        public Opportunity Opportunity { get; set; }

        public bool IsDisplayble(StudyMode studyMode)
        {
            switch (studyMode)
            {
                case StudyMode.FullTime:
                case StudyMode.PartTime:
                case StudyMode.Flexible:
                    return true;
                default:
                    return false;
            }
        }

        public bool IsDisplayble(AttendanceMode attendanceMode)
        {
            switch (attendanceMode)
            {
                case AttendanceMode.FaceToFace:
                case AttendanceMode.MixedMode:
                case AttendanceMode.NotKnown:
                    return false;
                default:
                    return true;
            }
        }

        public bool IsDisplayble(AttendancePattern attendancePattern)
        {
            switch (attendancePattern)
            {
                case AttendancePattern.Customised:
                case AttendancePattern.NotKnown:
                case AttendancePattern.NotApplicable:
                    return false;
                default:
                    return true;
            }
        }

    }
}
