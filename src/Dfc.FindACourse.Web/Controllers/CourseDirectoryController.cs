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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
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


        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService
            , IMemoryCache memoryCache, ITelemetryClient telemetryClient, IOptions<App> appSettings,
            ICourseDirectory courseDirectory, IFileHelper fileHelper)
        {
            Configuration = configuration;
            Service = courseDirectoryService;
            Cache = memoryCache;
            Telemetry = telemetryClient;
            Settings = appSettings;
            CourseDirectory = courseDirectory;
            Files = fileHelper;
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
        public ActionResult CourseSearchResult([FromQuery] CourseSearchRequestModel requestModel)
        {
            var dtStart = DateTime.Now;
            if (!ModelState.IsValid)
            {
                Telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }

            var criteria = CourseDirectory.CreateCourseSearchCriteria(requestModel);
            var result = Service.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1));

            if (result.HasValue && result.IsSuccess && !result.IsFailure)
            {
                var regionsOnly = result.Value.Items.Where(x => x.Opportunity.HasRegion);
                Telemetry.TrackEvent($"CourseSearch for: {requestModel.SubjectKeyword} took: { (DateTime.Now - dtStart).TotalMilliseconds.ToString()} ms.");
            }
            else
            {
                Telemetry.TrackEvent($"CourseSearch: Invalid.");
                return View();
            }
            //DEBUG_FIX - Add the flush to see if working straightaway
            Telemetry.Flush();

            return View(new CourseSearchResultViewModel(result) { SubjectKeyword = requestModel.SubjectKeyword, Location = requestModel.Location });
            


            
        }



        /// <summary>
        /// Autocomplete for loading of the synnonyms file
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        // GET: AutoComplete
        public JsonResult Autocomplete(string parm)
        {
            if (null != parm)
            {
               // List<Grouping<bool, string>> comp = DataService.AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.Contains(parm.ToUpper())).ToList();
               // var b = JsonConvert.SerializeObject(comp);
                //var c = JsonConvert.DeserializeObject<List<Grouping<bool,string>>>(b);
                var result = CourseDirectory.AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.Contains(parm.ToUpper()))
                    .OrderByDescending(x => x.Key) //order groups
                    .SelectMany(g => g.OrderBy(x => x)) //order items in each group
                    .Distinct()
                    .ToList();
                //Debug
                JsonResult autoData = new JsonResult(result);
                return Json(result);
            }
            return Json(null);
        }


    }

    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {

        readonly List<TElement> elements;

        public Grouping(IGrouping<TKey, TElement> grouping)
        {
            if (grouping == null)
                throw new ArgumentNullException("grouping");
            Key = grouping.Key;
            elements = grouping.ToList();
        }

        public TKey Key { get; private set; }

        public IEnumerator<TElement> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

    }
}