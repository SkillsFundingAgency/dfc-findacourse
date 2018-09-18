using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;

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


        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService
            , IMemoryCache memoryCache, ITelemetryClient telemetryClient, IOptions<App> appSettings,
            ICourseDirectory courseDirectory, IFileHelper fileHelper, ICourseDirectoryHelper requestModelHelper, IPostcodeService postcodeService)
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
        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
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

            Telemetry.TrackEvent("Find A Course Start page");

           
            return View(indViewModel);
        }

        // GET: CourseDirectory
        // ASB TODO - Should we not be returning OK objects? rather than empty Views if something goes wrong?
        public ActionResult CourseSearchResult([FromQuery]  CourseSearchRequestModel requestModel)
        {
            var dtStart = DateTime.Now;
            //if (!ModelState.IsValid)
            //{
            //    Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
            //    return View();
            //}

            if (!string.IsNullOrWhiteSpace(requestModel.Location))
            {
                var postcodeResult = PostcodeService.IsValidAsync(requestModel.Location).Result;
                if (postcodeResult.IsFailure)
                {
                    TempData["Location_IsInvalid"] = true;
                    TempData["Location_Postcode"] = requestModel.Location;
                    return RedirectToAction(nameof(Index));
                }
            }

            var criteria = CourseDirectory.CreateCourseSearchCriteria(requestModel);
            var result = Service.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, requestModel.PageNo));

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Search", requestModel.SubjectKeyword, dtStart))
                return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "Course Search: " + requestModel.SubjectKeyword.ToString() + ". " + (null != result ? result.Error : string.Empty) });

            //DEBUG_FIX - Add the flush to see if working straightaway
            //ASB TODO Why are we flushing here? We may not end up here due to higher up returns.
            //So that we could test the telemetry, a la the DEBUG_FIX
            Telemetry.Flush();

            int perPage = int.TryParse(Configuration["Tribal:PerPage"], out perPage) ? perPage : 0;

            return View(new CourseSearchResultViewModel(result) { SubjectKeyword = requestModel.SubjectKeyword, Location = requestModel.Location, DefaultRadiusDistance = (RadiusDistance)requestModel.LocationRadius, PerPage = perPage });
            
        }


        public IActionResult CourseDetails(int? id, string distance)
        {
            //Parmeters
            var dtStart = DateTime.Now;

            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }

            var result = Service.CourseItemDetail(id, null);

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Detail", id.Value.ToString(), dtStart))
                return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "Course Detail: " + id.Value.ToString() + ". " + (null != result ? result.Error:string.Empty) });

            //DEBUG_FIX - Add the flush to see if working straightaway ASB TODO AGain is this correct as wont get called if ModelState is Invalid
            Telemetry.Flush();

            return View(new CourseDetailViewModel(result.Value, !string.IsNullOrEmpty(distance) ? distance: string.Empty) { });
        }
      
        public IActionResult OpportunityDetails(int? id, string distance, int? oppid)
        {
            //Parmeters
            var dtStart = DateTime.Now;

            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }

            var result = Service.CourseItemDetail(id, oppid);

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Detail", id.Value.ToString(), dtStart))
                return View(nameof(Error), new Models.ErrorViewModel() { RequestId = "OpportunityDetails: " + id.Value.ToString() + ". " + (null != result ? result.Error : string.Empty) });

            //DEBUG_FIX - Add the flush to see if working straightaway ASB TODO AGain is this correct as wont get called if ModelState is Invalid
            Telemetry.Flush();

            return View(nameof(CourseDetails), new CourseDetailViewModel(result.Value, !string.IsNullOrEmpty(distance) ? distance : string.Empty) { });
        }


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