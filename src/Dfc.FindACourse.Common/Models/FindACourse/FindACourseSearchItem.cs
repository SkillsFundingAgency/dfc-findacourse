using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models.FindACourse
{
    public class FindACourseSearchItem : ValueObject<FindACourseSearchItem>, IFindACourseSearchItem
    {
        public float SearchScore { get; }
        public Venuelocation VenueLocation { get; }
        public float? GeoSearchDistance { get; }
        public float? ScoreBoost { get; }
        public string Id { get; }
        public string CourseId { get; }
        public string QualificationCourseTitle { get; }
        public string LearnAimRef { get; }
        public string NotionalNVQLevelv2 { get; }
        public object UpdatedOn { get; }
        public string VenueName { get; }
        public string VenueAddress { get; }
        public string VenueAttendancePattern { get; }
        public string ProviderName { get; }
        public object Region { get; }
        public int Status { get; }

        public FindACourseSearchItem(float searchscore, Venuelocation venueLocation, float? geoSearchDistance, float? scoreBoost, string id, string courseID, string qualificationCourseTitle
            , string learnAimRef, string notionalNVQLevelv2, string updatedOn, string venueName, string venueAddress, string venueAttendancePattern, string providerName, object region, int status)
        {
            SearchScore = searchscore;
            VenueLocation = venueLocation;
            GeoSearchDistance = geoSearchDistance;
            ScoreBoost = scoreBoost;
            Id = id;
            CourseId = courseID;
            QualificationCourseTitle = qualificationCourseTitle;
            LearnAimRef = learnAimRef;
            NotionalNVQLevelv2 = notionalNVQLevelv2;
            UpdatedOn = updatedOn;
            VenueName = venueName;
            VenueAddress = venueAddress;
            VenueAttendancePattern = venueAttendancePattern;
            ProviderName = providerName;
            Region = region;
            Status = status;


        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SearchScore;
            yield return VenueLocation;
            yield return GeoSearchDistance;
            yield return ScoreBoost;
            yield return Id;
            yield return CourseId;
            yield return QualificationCourseTitle;
            yield return LearnAimRef;
            yield return NotionalNVQLevelv2;
            yield return UpdatedOn;
            yield return VenueName;
            yield return VenueAddress;
            yield return VenueAttendancePattern;
            yield return ProviderName;
            yield return Region;

            yield return Status;
        }
    }
    public class Venuelocation
    {


        string Type { get; set; }
        float[] Coordinates { get; set; }
        Crs Crs { get; set; }
        public Venuelocation(string types, float[] coords, Crs crs)
        {
            Type = types;
            Coordinates = coords;
            Crs = crs;

        }
    }
    public class Crs
    {
        string Type { get; set; }
        Properties Properties { get; set; }
        public Crs(string type, Properties prop)
        {
            Type = type;
            Properties = prop;
        }

    }
    public class Properties
    {
        string Name { get; set; }

        public Properties(string name)
        {
            Name = name;
        }
    }

}
