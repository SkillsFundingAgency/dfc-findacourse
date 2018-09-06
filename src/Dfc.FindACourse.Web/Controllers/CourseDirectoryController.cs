using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Dfc.FindACourse.Web.ViewModels.CourseDirectory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights;
using Dfc.FindACourse.Common.Settings;

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        public IConfiguration _configuration;
        private readonly ICourseDirectoryService _courseDirectoryService;
        private IMemoryCache _cache;
        private FileHelper _fileHelper;
        private TelemetryClient _telemetry;
        private readonly IOptions<App> _appSettings;

        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService, IMemoryCache memoryCache, TelemetryClient telemetryClient, IOptions<App> appSettings)
        {
            _configuration = configuration;
            _courseDirectoryService = courseDirectoryService;
            _cache = memoryCache;
            _fileHelper = new FileHelper(configuration, memoryCache, telemetryClient);
            _telemetry = telemetryClient;
            _appSettings = appSettings;
            
        }
        
        // GET: CourseDirectory
        public ActionResult Index()
        {
            var indVM = new IndexViewModel
            {
                QualificationLevels = GetQualificationLevels()
            };


            _telemetry.TrackEvent("Find A Course Start page");


            return View(indVM);
        }

        // GET: CourseDirectory
        public ActionResult CourseSearchResult([FromQuery] CourseSearchRequestModel requestModel)
        {
            //Log response time
            var dtStart = DateTime.Now;
            var parmQualLevels = new List<QualLevel>();
            var parmStudyModes = new List<StudyMode>();
            var allQualLevels = _fileHelper.LoadQualificationLevels();


            //DEBUG
            int distance = -1;
            int quallevel = -1;
            int.TryParse(this.Request.Query["LocationRadius"], out distance);
            if(!string.IsNullOrEmpty(this.Request.Query["QualificationLevel"])) int.TryParse(this.Request.Query["QualificationLevel"], out quallevel);
            string location = this.Request.Query["Location"];

            if(!string.IsNullOrEmpty(location)) requestModel.Location = location;
            if(distance > -1) requestModel.Distance = distance;
            //Pass in the Qual Level from Query on first page and check model from second page
            if (quallevel > -1 || (requestModel.QualificationLevels != null && requestModel.QualificationLevels.Length > 0))
            { 
                requestModel.QualificationLevels = new int[] { quallevel };
                //Now Populate Qual Levels values from int array
                requestModel.QualificationLevels.ToList().ForEach(
                                       q => parmQualLevels.Add(
                                                   allQualLevels.Where(x => x.Key == q.ToString()).FirstOrDefault()));
            }

            //Debuging - Sample Vars to be passed in from UI, here for testing

            //bool? dfeFunded = null;
            //requestModel.QualificationLevels = new int[] { 3, 4 };
            //requestModel.IsDfe1619Funded = dfeFunded;
            //requestModel.StudyModes = new int[] { 0, 2};

            //var arrStudyModes = requestModel.StudyModes.Cast<StudyMode>().ToArray();

            //END DEBUG


            if (ModelState.IsValid)
            {
                var criteria = new CourseSearchCriteria(requestModel.SubjectKeyword, 
                                                            parmQualLevels, 
                                                                requestModel.Location, 
                                                                    requestModel.Distance.Value,
                                                                        requestModel.IsDfe1619Funded
                                                                        //,requestModel.StudyModes.Cast<StudyMode>().ToArray().ToList()
                                                                        ) {};
                
                var result = _courseDirectoryService.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1));

                var regionsOnly = result.Value.Items.Where(x => x.Opportunity.HasRegion);


                _telemetry.TrackEvent($"CourseSearch for: {requestModel.SubjectKeyword} took: { (DateTime.Now - dtStart).TotalMilliseconds.ToString()} ms.");
                //DEBUG_FIX - Add the flush to see if working straightaway
                _telemetry.Flush();

                return View(new CourseSearchResultViewModel(result) { SubjectKeyword = requestModel.SubjectKeyword, Location = requestModel.Location });
            }
            else
            {
                _telemetry.TrackEvent($"CourseSearch: ModelState Invalid.");
                return View();
            }


            
        }

        // GET: CourseDirectory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseDirectory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseDirectory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDirectory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseDirectory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDirectory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseDirectory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private IEnumerable<SelectListItem> GetQualificationLevels()
        {
            var searchTerms = _fileHelper.LoadQualificationLevels();
            var roles = searchTerms
                        .Where(y => y.Display)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Key,
                                    Text = x.Text
                                }
                                );

            return new SelectList(roles, "Value", "Text");
        }
        /// <summary>
        /// Autocomplete for loading of the synnonyms file
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public JsonResult Autocomplete(string parm)
        {
            if (null != parm)
            {
                var result = AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.Contains(parm.ToUpper()))
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
        /// <summary>
        /// Load the XML Document from a relative path and cache the serialized model for searching
        /// Match the search parm to those in the file
        /// Correct for common misspellings and re-apply search with those
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<string> AutoSuggestCourseName(string search)
        {
            var searchTerms = _fileHelper.LoadSynonyms();

            bool found = false;
            XmlNodeList expnData = searchTerms.GetElementsByTagName("expansion");

            foreach (XmlNode nData in expnData)
            {

                XmlNodeList oNode = nData.SelectNodes(".//sub"); 

                found = false;
                foreach (XmlNode nChilddata in oNode)
                    //if the child node has the search text then break out and add all elements of the expansion to the results
                    if (nChilddata.InnerText.Contains(search))
                        found = true;

                if (found)
                    foreach (XmlNode nChilddata in oNode)
                        yield return nChilddata.InnerText;

            }

            if (search.Length > 2)
            {
                //now check for common misspellings
                foreach (XmlNode nRepData in searchTerms.GetElementsByTagName("replacement"))
                {
                    foreach (XmlNode nPatdata in nRepData.SelectNodes(".//pat"))
                    {
                        //if the pat node has the search text return all sub nodes
                        if (nPatdata.InnerText.ToUpper().Contains(search))
                        {
                            foreach (XmlNode nSubRepdata in nRepData.SelectNodes(".//sub"))
                            {
                                yield return nSubRepdata.InnerText;
                                foreach (XmlNode nData in expnData)
                                {

                                    XmlNodeList oNode = nData.SelectNodes(".//sub");

                                    found = false;
                                    foreach (XmlNode nChilddata in oNode)
                                        //if the child node has the search text then break out and add all elements of the expansion to the results too
                                        if (nChilddata.InnerText.Contains(nSubRepdata.InnerText))
                                            found = true;

                                    if (found)
                                        foreach (XmlNode nChilddata in oNode)
                                            yield return nChilddata.InnerText;

                                }

                            }
                        }

                    }
                }
            }
           
          
        }

    }
}