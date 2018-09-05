using System;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IOpportunity
    {
        int Id { get; }
        StudyMode StudyMode { get; }
        AttendanceMode AttendanceMode { get; }
        AttendancePattern AttendancePattern { get; }
        bool IsDfe1619Funded { get; }
        IDescriptionDate StartDate { get; }
        IVenue Venue { get; }
        bool HasVenue { get; }
        string Region { get; }
        bool HasRegion { get; }
        IDuration Duration { get; }
    }
}