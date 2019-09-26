using System;
using System.Linq;
using System.Text;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseSearch : ICourseSearch
    {
        public IServiceHelper Helper { get; }

        public CourseSearch(IServiceHelper helper)
        {
            Helper = helper;
        }

        public SearchCriteriaStructure CreateSearchCriteriaStructure(ICourseSearchCriteria criteria, string apiKey)
        {
            return new SearchCriteriaStructure
            {
                APIKey = apiKey,
                SubjectKeyword = criteria.SubjectKeyword.Contains(" ") ? $"'{criteria.SubjectKeyword}'" : criteria.SubjectKeyword,
                QualificationLevels = criteria.QualificationLevels.ToArray(),
                Location = Helper.GetTownOrPostcode(criteria.TownOrPostcode),
                Distance = Helper.GetDistance(criteria),
                DFE1619Funded = Helper.GetDfe1619Funded(criteria),
                StudyModes = Helper.GetStudyModes(criteria),
                DistanceSpecified = Helper.IsDistanceSpecified(criteria),
                AttendanceModes = criteria.AttendanceModes.ToArray(),
                AttendancePatterns = criteria.AttendancePatterns.ToArray()
            };
        }

        public CourseListRequestStructure CreateCourseListRequestStructure(IPagingOptions options,
            SearchCriteriaStructure searchCriteria, string recordsPerPage)
        {
            var request = new CourseListRequestStructure()
            {
                CourseSearchCriteria = searchCriteria,
                SortBy = options.SortBy.ToSortType(),
                SortBySpecified = true,
                PageNo = options.PageNo.ToString(),
                RecordsPerPage = recordsPerPage 
            };
            return request;
        }

        public CourseSearchResult CreateCourseSearchResult(CourseListResponseStructure response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (response.CourseDetails == null)
            {
                return new CourseSearchResult(0, 0, 0, new CourseItem[] { });
            }

            var noOfPages = response.ResultInfo.NoOfPages.ToIntOrValue(0);
            var noOfRecords = response.ResultInfo.NoOfRecords.ToIntOrValue(0);
            var pageNo = response.ResultInfo.PageNo.ToIntOrValue(0);
            var courseItems = Helper.CourseItems(response);

            return new CourseSearchResult(noOfPages, noOfRecords, pageNo, courseItems);
        }

    }
}
