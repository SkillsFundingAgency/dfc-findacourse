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
        public string CourseRunId { get; }
        public string QualificationCourseTitle { get; }
        public string LearnAimRef { get; }
        public string NotionalNVQLevelv2 { get; }
        public object UpdatedOn { get; }
        public string VenueName { get; }
        public string VenueAddress { get; }
        public string VenueAttendancePattern { get; }
        public string ProviderName { get; }
        public object Region { get; }
       
        //new vars
        public string Weighting { get; }
        public string VenueStudyMode { get; }
        public string DeliveryMode { get; }
        public DateTime StartDate { get; }
        public string VenueTown { get; }
        public float? Cost { get; }
        public string CostDescription { get; }
        public string CourseText { get; }
        public string VenueAttendancePatternDescription { get; }
        public string VenueStudyModeDescription { get; }
        public string DeliveryModeDescription { get; }
        public string UKPRN { get; }

        public int Status { get; }
        public FindACourseSearchItem(float searchscore, Venuelocation venueLocation, float? geoSearchDistance, float? scoreBoost, string id, string courseID, string courserunID, string qualificationCourseTitle
            , string learnAimRef, string notionalNVQLevelv2, string updatedOn, string venueName, string venueAddress, string venueAttendancePattern, string providerName, object region, 
            string weighting, string venueStudyMode, string deliveryMode, DateTime startDate, string venuetown, float? cost, string costdescription, string coursetext, string venueattendancepatterndesc,
            string venuestudymodedesc, string deliverymodedesc, string ukprn,
                
            int status)
        {
            SearchScore = searchscore;
            VenueLocation = venueLocation;
            GeoSearchDistance = geoSearchDistance;
            ScoreBoost = scoreBoost;
            Id = id;
            CourseId = courseID;
            CourseRunId = courserunID;
            QualificationCourseTitle = qualificationCourseTitle;
            LearnAimRef = learnAimRef;
            NotionalNVQLevelv2 = notionalNVQLevelv2;
            UpdatedOn = updatedOn;
            VenueName = venueName;
            VenueAddress = venueAddress;
            VenueAttendancePattern = venueAttendancePattern;
            ProviderName = providerName;
            Region = region;
            Weighting = weighting;
            VenueStudyMode = venueStudyMode;
            DeliveryMode = deliveryMode;
            StartDate = startDate;
            VenueTown = venuetown;
            Cost = cost.HasValue ? cost.Value : 0.0f;
            CostDescription = costdescription;
            CourseText = coursetext;
            VenueAttendancePatternDescription = venueattendancepatterndesc;
            VenueStudyModeDescription = venuestudymodedesc;
            DeliveryModeDescription = deliverymodedesc;
            UKPRN = ukprn;



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
