using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tribal;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseDirectoryService : ICourseDirectoryService
    {
        public ICourseDirectoryServiceConfiguration Configuration { get; }
        public ICourseSearch CourseSearch { get; }
        public ServiceInterface ServiceClient { get; }
        public ITelemetryClient TelemetryClient { get; }

        public CourseDirectoryService(
            ICourseDirectoryServiceConfiguration configuration, 
            ICourseSearch courseSearch, 
            ServiceInterface serviceClient,
            ITelemetryClient telemetryClient)
        {
            Configuration = configuration;
            CourseSearch = courseSearch;
            ServiceClient = serviceClient;
            TelemetryClient = telemetryClient;
        }

        public IResult<CourseSearchResult> CourseDirectorySearch(ICourseSearchCriteria criteria, IPagingOptions options)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            try
            {
                var searchCriteria = CourseSearch.CreateSearchCriteriaStructure(criteria, Configuration.ApiKey);
                var request = CourseSearch.CreateCourseListRequestStructure(options, searchCriteria, Configuration.PerPage.ToString());
                var task = ServiceClient.CourseListAsync(new CourseListInput { CourseListRequest = request });
                Task.WaitAll(task);

                return Result.Ok(CourseSearch.CreateCourseSearchResult(task.Result.CourseListResponse));
            }
            catch (Exception e)
            {
                ServiceClient.Dispose();

                TelemetryClient.TrackEvent($"Service = {nameof(CourseDirectoryService)}: Method = {nameof(CourseDirectorySearch)}: Exception Message = {e.Message}");
                TelemetryClient.TrackException(e);

                return Result.Fail<CourseSearchResult>(e.Message);
            }
        }

        public IResult<Common.Models.CourseItemDetail> CourseItemDetail(int? courseDetailsId, int? opportunityId)
        {
            if (courseDetailsId == null)
                throw new ArgumentNullException(nameof(courseDetailsId));
            try
            {
                
                var request = new CourseDetailInput()
                {
                    APIKey = Configuration.ApiKey,
                    CourseID = new string[] { courseDetailsId.Value.ToString() }


                };
                var task = ServiceClient.CourseDetailAsync(request);
                Task.WaitAll(task);
                var taskResult = task.Result;

                if (taskResult.CourseDetails == null)
                {
                    var result = new CourseItem();
                    return Result.Fail<CourseItemDetail>("No Course Details found");
                }

                //This will create a new CourseItemDetail model, that contains the Coursedetail, Opportunity, Provider and Venue
                //Password back to calling controller function, and ViewModel contructor
                //DFC - 4372
                var courseDetails = taskResult.CourseDetails
                    .Select(x => new CourseItemDetail(
                        x.Course.ToCourseDetail(), 
                            x.Opportunity.ToOpportunities(opportunityId).ToList(), 
                                x.Provider.ToProvider(),
                                    (null != x.Venue && null != x.Venue[0]) ? x.Venue.ToVenues() : null
                       )).FirstOrDefault();

                return Result.Ok<CourseItemDetail>(courseDetails);
            }
            catch (Exception e)
            {
                ServiceClient.Dispose();

                TelemetryClient.TrackEvent($"Service = {nameof(CourseDirectoryService)}: Method = {nameof(CourseItemDetail)}: Exception Message = {e.Message}");
                TelemetryClient.TrackException(e);

                return Result.Fail<CourseItemDetail>(e.Message);
            }
        }
       
    }

}