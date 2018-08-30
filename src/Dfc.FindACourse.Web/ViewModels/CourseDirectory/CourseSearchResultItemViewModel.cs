using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseSearchResultItemViewModel
    {
        public string CourseTitle { get; set; }
        public string QualificationLevel { get; set; }
        public string StudyMode { get; set; }
        public string AttendanceMode { get; set; }
        public string AttendencePattern { get; set; }
        public string ProviderName { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string StartDate { get; set; }
        public string Duration { get; set; }
    }
}
