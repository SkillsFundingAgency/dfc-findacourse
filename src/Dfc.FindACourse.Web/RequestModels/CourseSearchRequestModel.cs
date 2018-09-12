﻿using System.ComponentModel.DataAnnotations;
using Dfc.FindACourse.Web.Interfaces;

namespace Dfc.FindACourse.Web.RequestModels
{
    public class CourseSearchRequestModel : ICourseSearchRequestModel
    {
        [Display(Name = "Course name")]
        [Required]
        public string SubjectKeyword { get; set; }
        public string Location { get; set; }
        public int[] QualificationLevels { get; set; }
        public int[] StudyModes { get; set; }
        public int[] AttendanceModes { get; set; }
        public int[] AttendancePatterns { get; set; }
        public bool? IsDfe1619Funded { get; set; }
        public string LocationCoordinates { get; set; }
        public int LocationRadius { get; set; }
        public string QualificationLevel { get; set; }
        public int PageNo { get; set; }
    }
}
