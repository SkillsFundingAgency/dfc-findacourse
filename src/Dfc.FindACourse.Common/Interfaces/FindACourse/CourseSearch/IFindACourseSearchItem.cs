using System;
using Microsoft.Spatial;
using Dfc.FindACourse.Common.Models.FindACourse.Enums;
using System.Collections.Generic;
using System.Text;
using Dfc.FindACourse.Common.Models.FindACourse;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IFindACourseSearchItem
    {

        float SearchScore { get; }
        Venuelocation VenueLocation { get; }
        float? GeoSearchDistance { get; }
        float? ScoreBoost { get; }
        string Id { get; }
        string CourseId { get; }
        string QualificationCourseTitle { get; }
        string LearnAimRef { get; }
        string NotionalNVQLevelv2 { get; }
        object UpdatedOn { get; }
        string VenueName { get; }
        string VenueAddress { get; }
        string VenueAttendancePattern { get; }
        string ProviderName { get; }
        object Region { get; }
        int Status { get; }

    }
    public interface IVenuelocation
    { 


       string type { get; }
       float[] coordinates { get; }
       Crs crs { get; }
    }
    public interface Crs
    {
        string type { get; }
        IProperties properties { get; }

    }
    public interface IProperties
    {
        string name { get; }
    }


       


    
}
