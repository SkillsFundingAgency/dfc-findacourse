﻿using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseSearchResultItemViewModel
    {
        
        public CourseSearchResultItemViewModel(ICourseItem item)
        {
            CourseTitle = item.Course.Title;
            QualificationLevel = item.Course.QualificationLevel;
            StudyMode = item.Opportunity.StudyMode;
            AttendanceMode = item.Opportunity.AttendanceMode;
            AttendencePattern = item.Opportunity.AttendancePattern;
            ProviderName = item.Provider.Name;
            Location = (item.Opportunity.Venue != null && item.Opportunity.Venue.Name  != null) ? item.Opportunity.Venue.Name : string.Empty;
            Distance = (item.Opportunity.Venue != null && item.Opportunity.Venue.Distance.HasValue) ? item.Opportunity.Venue.Distance.Value :0.0;
            StartDate = item.Opportunity.StartDate.HasValue ? item.Opportunity.StartDate.Value : default(DateTime);
            Duration = item.Opportunity.Duration.Value.ToString();
        }


        public string CourseTitle { get; set; }
        public QualificationLevel QualificationLevel { get; set; }
        public StudyMode StudyMode { get; set; }
        public AttendanceMode AttendanceMode { get; set; }
        public AttendancePattern AttendencePattern { get; set; }
        public string ProviderName { get; set; }
        public string Location { get; set; }
        public double Distance { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }
    }
}
