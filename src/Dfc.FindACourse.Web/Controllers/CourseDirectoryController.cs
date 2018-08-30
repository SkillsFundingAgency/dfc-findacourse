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
using System.Xml.Serialization;
using Microsoft.ApplicationInsights;

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        public IConfiguration _configuration;
        private readonly ICourseDirectoryService _courseDirectoryService;
        private IMemoryCache _cache;
        private FileHelper _fileHelper;
        private TelemetryClient _telemetry;

        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _courseDirectoryService = courseDirectoryService;
            _cache = memoryCache;
            _fileHelper = new FileHelper(configuration, memoryCache);
            _telemetry = new TelemetryClient();

        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
            var indVM = new IndexViewModel
            {
                QualificationLevels = GetQualificationLevels()
            };
            _telemetry.TrackEvent("Index");
            return View(indVM);
        }

        // GET: CourseDirectory
        public ActionResult CourseSearchResult([FromQuery] CourseSearchRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new CourseSearchCriteria(requestModel.SubjectKeyword)
                {
                    
                };
                _telemetry.TrackEvent($"CourseSearch: {requestModel.SubjectKeyword}.");
                var result = _courseDirectoryService.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1));

                var regionsOnly = result.Value.Items.Where(x => x.Opportunity.HasRegion);
            }
            else
            {
                _telemetry.TrackEvent($"CourseSearch: State Invalid.");
            }


            return View();
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
                                        //if the child node has the search text then break out and add all elements of the expansion to the results
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
    //[Serializable, XmlRoot("thesaurus")]
    //public class Thesaurus
    //{
    //    [XmlArray("Expansion")]
    //    public List<string> Expansion { get; set; }
    //}
    //public class Expansion
    //{
    //    [XmlArray("Sub")]
    //    public List<string> Sub { get; set; }
    //}

}