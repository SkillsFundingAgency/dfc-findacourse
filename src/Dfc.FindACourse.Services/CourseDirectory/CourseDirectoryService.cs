using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Common.Models.FindACourse;
using Dfc.FindACourse.Services.FindACourse;
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
        public IFindACourseConfiguration FaCConfiguration { get; }
        public ICourseAPIConfiguration CourseAPIConfiguration { get; }
        public ICourseSearch CourseSearch { get; }
        public ServiceInterface ServiceClient { get; }
        public ITelemetryClient TelemetryClient { get; }

        public CourseDirectoryService(
            ICourseDirectoryServiceConfiguration configuration,
            IFindACourseConfiguration facconfiguration,
            ICourseAPIConfiguration courseconfig,
            ICourseSearch courseSearch, 
            ServiceInterface serviceClient,
            ITelemetryClient telemetryClient)
        {
            Configuration = configuration;
            FaCConfiguration = facconfiguration;
            CourseAPIConfiguration = courseconfig;
            CourseSearch = courseSearch;
            ServiceClient = serviceClient;
            TelemetryClient = telemetryClient;
        }

        public IResult<FindACourseSearchResult> CourseDirectorySearch(ICourseSearchCriteria criteria, IPagingOptions options)
        {
            FindACourseService fac = new FindACourseService(FaCConfiguration, CourseAPIConfiguration);

            return fac.FindACourseSearch(criteria, options).Result;

        }

        public IResult<Common.Models.FindACourse.FindACourseDetail> CourseItemDetail(string CourseId, string RunId)
        {
            FindACourseService fac = new FindACourseService(FaCConfiguration, CourseAPIConfiguration);
            return fac.CourseGet(CourseId, RunId).Result;

        }
    }

}