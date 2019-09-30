using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.Middleware;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Linq;

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        public IConfiguration Configuration { get; }
        public ICourseDirectoryService Service { get; }
        public IMemoryCache Cache { get; }
        public ITelemetryClient Telemetry { get; }
        public IOptions<App> Settings { get; }
        public ICourseDirectory CourseDirectory { get; }
        public IFileHelper Files { get; }
        public ICourseDirectoryHelper CourseDirectoryHelper { get; }
        public IPostcodeService PostcodeService { get; }
        public ICorrelationContextAccessor CorrelationContextAccessor { get; }


        public CourseDirectoryController(
            IConfiguration configuration, 
            ICourseDirectoryService courseDirectoryService, 
            IMemoryCache memoryCache, 
            ITelemetryClient telemetryClient, 
            IOptions<App> appSettings,
            ICourseDirectory courseDirectory, 
            IFileHelper fileHelper, 
            ICourseDirectoryHelper requestModelHelper, 
            IPostcodeService postcodeService, 
            ICorrelationContextAccessor correlationContextAccessor)
        {
            Configuration = configuration;
            Service = courseDirectoryService;
            Cache = memoryCache;
            Telemetry = telemetryClient;
            Settings = appSettings;
            CourseDirectory = courseDirectory;
            Files = fileHelper;
            CourseDirectoryHelper = requestModelHelper;
            PostcodeService = postcodeService;
            CorrelationContextAccessor = correlationContextAccessor;
        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
            Telemetry.TrackEvent($"Logging: Started: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(Index)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            var isPostcodeInvalid = false;
            var location = default(string);
            
            if (TempData != null)
            {
                isPostcodeInvalid = (TempData["Location_IsInvalid"] != null && (bool)TempData["Location_IsInvalid"] == true);
                location = (TempData["Location_Postcode"] != null && !string.IsNullOrWhiteSpace((string)TempData["Location_Postcode"])) ? (string)TempData["Location_Postcode"] : default(string);
            }

            var indViewModel = new IndexViewModel
            {
                QualificationLevels = CourseDirectory.GetQualificationLevels().ToList(),
                LocationHasError = isPostcodeInvalid,
                Location = location
            };

            if (TempData != null)
            {
                if (TempData["Location_Postcode"] != null)
                {
                    TempData.Remove("Location_Postcode");
                }

                if (TempData["Location_IsInvalid"] != null)
                {
                    TempData.Remove("Location_IsInvalid");
                }
            }

            Telemetry.TrackEvent($"Logging: Ended: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(Index)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            return View(indViewModel);
        }

        // GET: CourseDirectory
        // ASB TODO - Should we not be returning OK objects? rather than empty Views if something goes wrong?
        public ActionResult CourseSearchResult([FromQuery]  CourseSearchRequestModel requestModel)
        {
            Telemetry.TrackEvent($"Logging: Started: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(CourseSearchResult)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            var dtStart = DateTime.Now;
            var isPostcodeInvalid = false;

            if (TempData != null)
            {
                isPostcodeInvalid = (TempData["Location_IsInvalid"] != null && (bool)TempData["Location_IsInvalid"] == true);

                if (!string.IsNullOrWhiteSpace(requestModel.Location))
                {
                    var postcodeResult = PostcodeService.IsValidAsync(requestModel.Location).Result;
                    if (postcodeResult.IsFailure)
                    {
                        isPostcodeInvalid = true;
                        TempData["Location_IsInvalid"] = isPostcodeInvalid;
                        TempData["Location_Postcode"] = requestModel.Location;

                        if (new UriBuilder(Request.Headers["Referer"]).Path != Request.Path)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                else
                {
                    TempData.Remove("Location_IsInvalid");
                    TempData.Remove("Location_Postcode");
                }
            }

            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Starting to create course search criteria.");
            var criteria = CourseDirectory.CreateCourseSearchCriteria(requestModel);
            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Finished creating course search criteria.");

            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Starting call to course directory search from the course directory service.");
            var result = Service.CourseDirectorySearch(criteria, new PagingOptions(CourseDirectoryHelper.GetSortBy(requestModel.SortBy), requestModel.PageNo));
            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Finished calling course directory search from the course directory service.");

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Search", requestModel.SubjectKeyword, dtStart))
                return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "Course Search: " + requestModel.SubjectKeyword.ToString() + ". " + (null != result ? result.Error : string.Empty) });

            //DEBUG_FIX - Add the flush to see if working straightaway
            //ASB TODO Why are we flushing here? We may not end up here due to higher up returns.
            //So that we could test the telemetry, a la the DEBUG_FIX
            Telemetry.Flush();

            int perPage = int.TryParse(Configuration["Tribal:PerPage"], out perPage) ? perPage : 0;

            Telemetry.TrackEvent($"Logging: Ended: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(CourseSearchResult)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            return View(new CourseSearchResultViewModel(result)
            {
                SubjectKeyword = requestModel.SubjectKeyword,
                Location = requestModel.Location,
                LocationHasError = isPostcodeInvalid,
                LocationRadius = (RadiusDistance)requestModel.LocationRadius,
                PerPage = perPage,
                StudyModes = requestModel.StudyModes,
                AttendanceModes = requestModel.AttendanceModes,
                AttendancePatterns = requestModel.AttendancePatterns,
                QualificationLevels = requestModel.QualificationLevels,
                IsDfe1619Funded = requestModel.IsDfe1619Funded,
                SortBy = CourseDirectoryHelper.GetSortBy(requestModel.SortBy),
            });
            
        }


        public IActionResult CourseDetails(string CourseId, string distance, string postcode)
        {
            Telemetry.TrackEvent($"Logging: Started: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(CourseDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            //Parmeters
            var dtStart = DateTime.Now;

            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(CourseDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");
                return View();
            }

            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Starting call to course item detail from the course directory service.");
            var result = Service.CourseItemDetail(CourseId, null);
            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Finished calling course item detail from the course directory service.");

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Detail", CourseId, dtStart))
                return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "Course Detail: " + CourseId + ". " + (null != result ? result.Error:string.Empty) });

            Telemetry.TrackEvent($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}] Ending call Controller = {nameof(CourseDirectoryController)}, Action = {nameof(CourseDetails)}");

            //DEBUG_FIX - Add the flush to see if working straightaway ASB TODO AGain is this correct as wont get called if ModelState is Invalid
            Telemetry.Flush();

            Telemetry.TrackEvent($"Logging: Ended: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(CourseDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

            return View(nameof(CourseDetails), new CourseDetailViewModel(result.Value, !string.IsNullOrEmpty(distance) ? distance: string.Empty, postcode, null) { });
        }
      
        //public IActionResult OpportunityDetails(string courseid, string distance, string runId, string postcode)
        //{
        //    Telemetry.TrackEvent($"Logging: Started: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(OpportunityDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

        //    //Parmeters
        //    var dtStart = DateTime.Now;

        //    if (!ModelState.IsValid)
        //    {
        //        Telemetry.TrackEvent($"CourseSearch: ModelState Invalid: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(OpportunityDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");
        //        return View();
        //    }

        //    var result = Service.CourseItemDetail(courseid, runId);

        //    if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Detail", courseid, dtStart))
        //        return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "OpportunityDetails: " + courseid + ". " + (null != result ? result.Error : string.Empty) });

        //    //DEBUG_FIX - Add the flush to see if working straightaway ASB TODO AGain is this correct as wont get called if ModelState is Invalid
        //    Telemetry.Flush();

        //    Telemetry.TrackEvent($"Logging: Ended: Controller = {nameof(CourseDirectoryController)}: Action = {nameof(OpportunityDetails)}: {nameof(Environment.MachineName)} = {Environment.MachineName}: {nameof(CorrelationContextAccessor.CorrelationContext.CorrelationId)} = {CorrelationContextAccessor.CorrelationContext.CorrelationId}");

        //    return View(nameof(CourseDetails), new CourseDetailViewModel(result.Value, !string.IsNullOrEmpty(distance) ? distance : string.Empty, postcode, runId) { });
        //}


        /// <summary>
        /// Autocomplete for loading of the synnonyms file
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        // GET: AutoComplete
        public JsonResult Autocomplete(string parm)
        {
            if (null == parm) return Json(null);

            var result = CourseDirectory.AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.Contains(parm.ToUpper()))
                .OrderByDescending(x => x.Key) //order groups
                .SelectMany(g => g.OrderBy(x => x)) //order items in each group
                .Distinct()
                .ToList();

            return Json(result);
        }
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new Dfc.FindACourse.Web.Models.ErrorViewModel { RequestId = "error" });
        }

    }
}