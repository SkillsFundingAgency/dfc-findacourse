using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseDetails : ICourseDetails
    {
        public CourseDetails(int courseid,
            string awardingBody,
            string entryRequirements,
            string assessmentMethod,
            string equipmentRequired,
            string uRL,
            string bookingURL,
            string tariffRequired,
            string lADID,
            string qualificationReferenceAuthority,
            string qualificationReference,
            string qualificationTitle,
            string level2EntitlementCategoryDesc,
            string level3EntitlementCategoryDesc,
            string sectorLeadBodyDesc,
            string accreditationStartDate,
            string accreditationEndDate,
            string certificationEndDate,
            string creditValue,
            string qCAGuidedLearningHours,
            string skillsForLifeTypeDesc



            )
        {
            CourseId = courseid;
            AwardingBody = awardingBody;
            EntryRequirements = entryRequirements;
            AssessmentMethod = assessmentMethod;
            EquipmentRequired = equipmentRequired;
            URL = uRL;
            BookingURL = bookingURL;
            TariffRequired = tariffRequired;
            LADID = lADID;
            QualificationReferenceAuthority = qualificationReferenceAuthority;
            QualificationReference = qualificationReference;
            QualificationTitle = qualificationTitle;
            Level2EntitlementCategoryDesc = level2EntitlementCategoryDesc;
            Level3EntitlementCategoryDesc = level3EntitlementCategoryDesc;
            SectorLeadBodyDesc = sectorLeadBodyDesc;
            AccreditationStartDate = accreditationStartDate;
            AccreditationEndDate = accreditationEndDate;
            CertificationEndDate = certificationEndDate;
            CreditValue = creditValue;
            QCAGuidedLearningHours = qCAGuidedLearningHours;
            SkillsForLifeTypeDesc = skillsForLifeTypeDesc;
        }
        public int CourseId { get; }

       //ublic int CourseId { get; }
        public string AwardingBody { get; }

        public string EntryRequirements { get; }

        public string AssessmentMethod { get; }

        public string EquipmentRequired { get; }

        public string URL { get; }

        public string BookingURL { get; }

        public string TariffRequired { get; }

        public string LADID { get; }

        public string QualificationReferenceAuthority { get; }

        public string QualificationReference { get; }

        public string QualificationTitle { get; }

        public string Level2EntitlementCategoryDesc { get; }

        public string Level3EntitlementCategoryDesc { get; }

        public string SectorLeadBodyDesc { get; }

        public string AccreditationStartDate { get; }

        public string AccreditationEndDate { get; }

        public string CertificationEndDate { get; }

        public string CreditValue { get; }

        public string QCAGuidedLearningHours { get; }

        public string SkillsForLifeTypeDesc { get; }

      

    }
}
