using Dfc.FindACourse.Common.Models.FindACourse.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IFindACourseRun
    {
        Guid id { get; set; }
        int? CourseInstanceId { get; set; }
        Guid? VenueId { get; set; }
        string CourseName { get; set; }
        string ProviderCourseID { get; set; }
        
        bool FlexibleStartDate { get; set; }
        DateTime? StartDate { get; set; }
        string CourseURL { get; set; }
        decimal? Cost { get; set; }
        string CostDescription { get; set; }
        DurationUnit DurationUnit { get; set; }
        int? DurationValue { get; set; }
        StudyMode StudyMode { get; set; }
        AttendancePattern AttendancePattern { get; set; }
        DeliveryMode DeliveryMode { get; set; }
        IEnumerable<string> Regions { get; set; }
    }
}
