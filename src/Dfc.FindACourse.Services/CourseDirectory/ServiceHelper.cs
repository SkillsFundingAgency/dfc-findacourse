using System.Collections.Generic;
using System.Linq;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class ServiceHelper : IServiceHelper
    {
        public string[] GetQualificationLevels(List<QualLevel> qualLevels)
        {
            var results = new string[] { };

            if (qualLevels != null && qualLevels.Count > 0)
            {
                results = qualLevels.Select(x => x.Level).ToArray();
            }

            return results;
        }

        public string GetTownOrPostcode(string townOrPostcode)
        {
            return !string.IsNullOrEmpty(townOrPostcode) ? townOrPostcode : string.Empty;
        }

        public float GetDistance(ICourseSearchCriteria searchCriteria)
        {
            var result = 0;
            if (searchCriteria.Distance.HasValue && !string.IsNullOrEmpty(searchCriteria.TownOrPostcode))
            {
                result = searchCriteria.Distance.Value;
            }

            return result;
        }

        public string GetDfe1619Funded(ICourseSearchCriteria searchCriteria)
        {
            var result = string.Empty;

            if (searchCriteria.IsDfe1619Funded.HasValue)
            {
                result = searchCriteria.IsDfe1619Funded.Value ? "Y" : "N";
            }

            return result;
        }

        public string[] GetStudyModes(ICourseSearchCriteria searchCriteria)
        {
            var results = new string[] { };

            if (searchCriteria.StudyModes != null && searchCriteria.StudyModes.Count > 0)
            {
                results = searchCriteria.StudyModes.ToArray();
            }

            return results;
        }

        //public string[] GetAttendanceModes(ICourseSearchCriteria searchCriteria)
        //{
        //    var results = new List<string>();

        //    if (searchCriteria.AttendanceModes != null && searchCriteria.AttendanceModes.Count > 0)
        //    {
                
        //    }

        //    return results.ToArray();
        //}

        //public string GetAttendanceMode(AttendanceMode attendanceMode)
        //{
        //    switch (attendanceMode)
        //    {
        //        case AttendanceMode.LocationCampus: "AM1"
        //    }
        //}

        public bool IsDistanceSpecified(ICourseSearchCriteria searchCriteria)
        {
            return searchCriteria.Distance.HasValue && searchCriteria.Distance.Value > 0;
        }

        public IEnumerable<CourseItem> CourseItems(CourseListResponseStructure response)
        {
            if (response == null) return new List<CourseItem>();
            if (response.CourseDetails == null) return new List<CourseItem>();
            if (response.CourseDetails.Length < 1) return new List<CourseItem>();

            var courseItems = response
                .CourseDetails
                .Select(x => new CourseItem(
                    x.Course.ToCourse(),
                    x.Opportunity.ToOpportunity(),
                    x.Provider.ToProvider()));
            return courseItems;
        }
    }
}
