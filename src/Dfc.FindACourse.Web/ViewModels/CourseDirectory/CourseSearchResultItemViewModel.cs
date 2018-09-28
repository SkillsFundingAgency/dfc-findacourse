using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseSearchResultItemViewModel
    {
        private static readonly string _distanceDisplayText = "Contact provider";

        
        public CourseSearchResultItemViewModel(ICourseItem item)
        {
            Id = item.Course.Id;
            CourseTitle = item.Course.Title;
            QualificationLevel = item.Course.QualificationLevel;
            StudyMode = item.Opportunity.StudyMode;
            AttendanceMode = item.Opportunity.AttendanceMode;
            AttendencePattern = item.Opportunity.AttendancePattern;
            ProviderName = item.Provider.Name;
            Location = (item.Opportunity.HasVenue) ? item.Opportunity.Venue.Address.ToString() : item.Opportunity.Region;
            Distance = DistanceDisplayText(item);
            //Distance = (item.Opportunity.HasVenue && item.Opportunity.Venue.Distance.HasValue) ? item.Opportunity.Venue.Distance.Value.ToString("0.0") : "0.0";
            StartDate = item.Opportunity.StartDate.ToString();
            Duration = item.Opportunity.Duration.ToString();
        }

        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public QualificationLevel QualificationLevel { get; set; }
        public StudyMode StudyMode { get; set; }
        public AttendanceMode AttendanceMode { get; set; }
        public AttendancePattern AttendencePattern { get; set; }
        public string ProviderName { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string StartDate { get; set; }
        public string Duration { get; set; }

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

        internal string DistanceDisplayText(ICourseItem item)
        {
            if (!item.Opportunity.HasVenue && item.Opportunity.HasRegion)
            {
                return _distanceDisplayText;
            }

            return $"{item.Opportunity.Venue.Distance.Value.ToString("0.0")} miles";
        }
    }
}
