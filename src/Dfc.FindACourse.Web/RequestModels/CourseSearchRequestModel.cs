﻿using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Web.RequestModels
{
    public class CourseSearchRequestModel
    {
        [Display(Name = "Course name")]
        [Required]
        public string SubjectKeyword { get; set; }
        public string TownOrPostcode { get; set; }
        public int? Distance { get; set; }
        public int[] QualificationLevels { get; set; }
        public int[] StudyModes { get; set; }
        public int[] AttendanceModes { get; set; }
        public int[] AttendancePatterns { get; set; }
        public bool? IsDfe1619Funded { get; set; }
        public string LocationCoordinates { get; set; }
    }
}