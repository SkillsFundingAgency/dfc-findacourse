using System;

namespace Dfc.FindACourse.Services.CourseDirectory.Interfaces
{
    public interface IOpportunity
    {
        int Id { get; }
        StudyMode StudyMode { get; }
        AttendanceMode AttendanceMode { get; }
        AttendancePattern AttendancePattern { get; }
        bool IsDfe1619Funded { get; }
        DateTime? StartDate { get; }
        IVenue Venue { get; }
        IDuration Duration { get; }
    }
}