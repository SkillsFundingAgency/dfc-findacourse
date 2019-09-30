using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Enums;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseDetailViewModel
    {
        //private CourseDetails value;


        /// <summary>
        /// Main view model constructor
        /// </summary>
        /// <param name="value"></param>
        public CourseDetailViewModel(ICourseItemDetail value, string distance, string postcode, string runId)
        {
            if (value != null)
            {
                CourseId = value.Coursedetails.CourseId;// Opportunity.Id;   
                CourseTitle = value.Coursedetails.CourseTitle;
                CourseSummary = value.Coursedetails.CourseSummary;
                QualificationLevel = value.Coursedetails.QualificationLevel;
                StudyMode = value.Opportunities[0].StudyMode;
                AttendanceMode = value.Opportunities[0].AttendanceMode;
                AttendencePattern = value.Opportunities[0].AttendancePattern;
                ProviderName = value.Provider.Name;
                Location = (value.Opportunities[0].HasVenue) ? value.Opportunities[0].Venue.Address.ToString() : value.Opportunities[0].Region;
                Distance = (value.Opportunities[0].HasVenue && value.Opportunities[0].Venue.Distance.HasValue) ? value.Opportunities[0].Venue.Distance.Value.ToString("0.0") : distance;
                StartDate = value.Opportunities[0].StartDate.ToString();
                Duration = value.Opportunities[0].Duration.ToString();
                AwardingBody = value.Coursedetails.AwardingBody;
                EntryRequirements = value.Coursedetails.EntryRequirements;
                AssessmentMethod = value.Coursedetails.AssessmentMethod;
                EquipmentRequired = value.Coursedetails.EquipmentRequired;
                URL = Uri.IsWellFormedUriString(value.Coursedetails.URL, UriKind.Absolute) ? value.Coursedetails.URL : string.Empty;
                BookingURL = Uri.IsWellFormedUriString(value.Coursedetails.BookingURL, UriKind.Absolute) ? value.Coursedetails.BookingURL : string.Empty;
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
                Venues = value.Venues != null ? value.Venues.AsEnumerable().Cast<Venue>().ToList(): null;
                Provider = (Provider)value.Provider;
                //Load Opportunities, passing in the venue list for linking, and the opportunityID to set order
                //Opportunities = LoadOpportunities(value, Venues, runId);
            }

            Postcode = postcode;
        }
        public CourseDetailViewModel(IFindACourseDetail value, string distance, string postcode, int? oppid)
        {
            if (value != null)
            {
                CourseId = value.CourseId.HasValue ? value.CourseId.Value : 0;
                CourseTitle = value.QualificationCourseTitle;
                CourseSummary = value.CourseDescription;
                //QualificationLevel = value.FindACourseRuns.FirstOrDefault().n.Coursedetails.QualificationLevel;
                //StudyMode = value.Opportunities[0].StudyMode;
                //AttendanceMode = value.Opportunities[0].AttendanceMode;
                //AttendencePattern = value.Opportunities[0].AttendancePattern;
                //ProviderName = value.Provider.Name;
                //Location = (value.Opportunities[0].HasVenue) ? value.Opportunities[0].Venue.Address.ToString() : value.Opportunities[0].Region;
                //Distance = (value.Opportunities[0].HasVenue && value.Opportunities[0].Venue.Distance.HasValue) ? value.Opportunities[0].Venue.Distance.Value.ToString("0.0") : distance;
                //StartDate = value.Opportunities[0].StartDate.ToString();
                //Duration = value.Opportunities[0].Duration.ToString();
                //AwardingBody = value.Coursedetails.AwardingBody;
                EntryRequirements = value.EntryRequirements;
                AssessmentMethod = value.HowYoullBeAssessed;
                EquipmentRequired = value.WhatYoullNeed;
                //URL = Uri.IsWellFormedUriString(value.Coursedetails.URL, UriKind.Absolute) ? value.Coursedetails.URL : string.Empty;
                //BookingURL = Uri.IsWellFormedUriString(value.Coursedetails.BookingURL, UriKind.Absolute) ? value.Coursedetails.BookingURL : string.Empty;
                //TariffRequired = value.Coursedetails.TariffRequired;
                LADID = value.LearnAimRef;
                //QualificationReferenceAuthority = value.Coursedetails.QualificationReferenceAuthority;
                //QualificationReference = value.Coursedetails.QualificationReference;
                //QualificationTitle = value.Coursedetails.QualificationTitle;
                //Level2EntitlementCategoryDesc = value.Coursedetails.Level2EntitlementCategoryDesc;
                //Level3EntitlementCategoryDesc = value.Coursedetails.Level3EntitlementCategoryDesc;
                //SectorLeadBodyDesc = value.Coursedetails.SectorLeadBodyDesc;
                //AccreditationStartDate = value.Coursedetails.AccreditationStartDate;
                //AccreditationEndDate = value.Coursedetails.AccreditationEndDate;
                //CertificationEndDate = value.Coursedetails.CertificationEndDate;
                //CreditValue = value.Coursedetails.CreditValue;
                //QCAGuidedLearningHours = value.Coursedetails.QCAGuidedLearningHours;
                //SkillsForLifeTypeDesc = value.Coursedetails.SkillsForLifeTypeDesc;
                //Venues = value.Venues != null ? value.Venues.AsEnumerable().Cast<Venue>().ToList() : null;
                //Provider = (Provider)value.Provider;
                ////Load Opportunities, passing in the venue list for linking, and the opportunityID to set order
                //Opportunities = LoadOpportunities(value, Venues, oppid);
            }

            Postcode = postcode;
        }
        private List<Opportunity> LoadOpportunities(ICourseItemDetail value, List<Venue> venues, int? oppid = null)
        {
            List<Opportunity> data = value.Opportunities.AsEnumerable().Cast<Opportunity>().OrderBy(o => o.StartDate.Date).ToList();

            //Check to see if we have venus and then load
            if (null != venues && venues.Count > 0)
            {
                foreach (Opportunity opp in data)
                {
                    if (opp.ItemsElementName[0] == ItemChoice.VenueID)
                        opp.Venue = (IVenue)venues.FirstOrDefault(v => v.VenueId == opp.Items[0]);
                }
                if (null != oppid && oppid.HasValue && oppid.Value > 0)
                    return data.OrderByDescending(x => x.Id == oppid.Value).ToList();
            }
            return data;
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

        public List<Venue> Venues { get; set; }
        public Provider Provider { get; set; }
        public List<Opportunity> Opportunities { get; set; }
        public string Postcode { get; set; }

        public bool IsDisplayable(StudyMode studyMode)
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

        public bool IsDisplayable(AttendanceMode attendanceMode)
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

        public bool IsDisplayable(AttendancePattern attendancePattern)
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
