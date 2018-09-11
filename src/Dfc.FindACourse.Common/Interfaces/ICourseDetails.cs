using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseDetails
    {
        //IVenue Venue { get; }
        int CourseId { get; }
        string CourseTitle { get; }
        string CourseSummary { get; }
        string AwardingBody { get; }
        string AssessmentMethod { get; }

        string EntryRequirements { get; }

        string EquipmentRequired { get; }

        string URL { get; }

        string BookingURL { get; }

        string TariffRequired { get; }

        string LADID { get; }

        //CourseDetailDataType dataType;

        string QualificationReferenceAuthority { get; }

        string QualificationReference { get; }

        string QualificationTitle { get; }

        string Level2EntitlementCategoryDesc { get; }

        string Level3EntitlementCategoryDesc { get; }

        string SectorLeadBodyDesc { get; }

        string AccreditationStartDate { get; }

        string AccreditationEndDate { get; }

        string CertificationEndDate { get; }

        string CreditValue { get; }

        string QCAGuidedLearningHours { get; }

        //CourseDetailIndependentLivingSkills independentLivingSkills;

        //CourseDetailSkillsForLifeFlag skillsForLifeFlag;

        string SkillsForLifeTypeDesc { get; }

        //CourseDetailERAppStatus eRAppStatus;

        //CourseDetailERTTGStatus eRTTGStatus;

        //CourseDetailAdultLRStatus adultLRStatus;

        //CourseDetailOtherFundingNonFundedStatus otherFundingNonFundedStatus;
    }
}
