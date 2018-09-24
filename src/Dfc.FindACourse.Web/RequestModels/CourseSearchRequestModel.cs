using System.ComponentModel.DataAnnotations;
using Dfc.FindACourse.Web.Interfaces;

namespace Dfc.FindACourse.Web.RequestModels
{
    public class CourseSearchRequestModel : ICourseSearchRequestModel
    {
        public CourseSearchRequestModel()
        {
            StudyModes = new int[] { };
            AttendanceModes = new int[] { };
            AttendancePatterns = new int[] { };
        }

        [Display(Name = "Course name")]
        [Required]
        public string SubjectKeyword { get; set; }
        public string Location { get; set; }
        public int[] QualificationLevels { get; set; } = new int[] { };
        public int[] StudyModes { get; set; }
        public int[] AttendanceModes { get; set; }
        public int[] AttendancePatterns { get; set; }
        public bool? IsDfe1619Funded { get; set; }
        public string LocationCoordinates { get; set; }
        public int LocationRadius { get; set; }
        public int PageNo { get; set; }
    }
}
