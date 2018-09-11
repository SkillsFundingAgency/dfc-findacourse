using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Xml;
using Dfc.FindACourse.Common.Interfaces;
using Microsoft.Extensions.Options;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Web.Interfaces;
using Newtonsoft.Json;

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


        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService
            , IMemoryCache memoryCache, ITelemetryClient telemetryClient, IOptions<App> appSettings,
            ICourseDirectory courseDirectory, IFileHelper fileHelper, ICourseDirectoryHelper requestModelHelper)
        {
            Configuration = configuration;
            Service = courseDirectoryService;
            Cache = memoryCache;
            Telemetry = telemetryClient;
            Settings = appSettings;
            CourseDirectory = courseDirectory;
            Files = fileHelper;
            CourseDirectoryHelper = requestModelHelper;
        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
            var indViewModel = new IndexViewModel
            {
                QualificationLevels = CourseDirectory.GetQualificationLevels()
            };

            Telemetry.TrackEvent("Find A Course Start page");

            return View(indViewModel);
        }

        // GET: CourseDirectory
        // ASB TODO - Should we not be returning OK objects? rather than empty Views if something goes wrong?
        public ActionResult CourseSearchResult([FromQuery] CourseSearchRequestModel requestModel)
        {
            var dtStart = DateTime.Now;
            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }

            var criteria = CourseDirectory.CreateCourseSearchCriteria(requestModel, CourseDirectoryHelper);
            var result = Service.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1));

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Search", requestModel.SubjectKeyword, dtStart)) return View();

            //DEBUG_FIX - Add the flush to see if working straightaway
            //ASB TODO Why are we flushing here? We may not end up here due to higher up returns.
            Telemetry.Flush();

            return View(new CourseSearchResultViewModel(result) { SubjectKeyword = requestModel.SubjectKeyword, Location = requestModel.Location });
            
        }


        // GET: CourseDirectory/Details/5
        public IActionResult CourseDetails(int? id)
        {
            //Parmeters
            var dtStart = DateTime.Now;

            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }

            var result = Service.CourseItemDetail(id);

            if (!CourseDirectory.IsSuccessfulResult(result, Telemetry, "Course Detail", id.Value.ToString(), dtStart)) return View();

            //DEBUG_FIX - Add the flush to see if working straightaway ASB TODO AGain is this correct as wont get called if ModelState is Invalid
            Telemetry.Flush();

            return View(new CourseDetailViewModel(result.Value) { });
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


    }
}