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

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        public IConfiguration _configuration;
        private readonly ICourseDirectoryService _courseDirectoryService;
        private IMemoryCache _cache;
        private FileHelper _fileHelper;


        public CourseDirectoryController(IConfiguration configuration, ICourseDirectoryService courseDirectoryService, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _courseDirectoryService = courseDirectoryService;
            _cache = memoryCache;
            _fileHelper = new FileHelper(configuration, memoryCache);

        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
            var indVM = new IndexViewModel
            {
                QualificationLevels = GetQualificationLevels()
            };
            return View(indVM);
        }

        // GET: CourseDirectory
        public ActionResult CourseSearch([FromQuery] CourseSearchRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new CourseSearchCriteria(requestModel.SubjectKeyword)
                {
                    
                };

                var result = _courseDirectoryService.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1));
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
                var result = AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.StartsWith(parm.ToUpper()))
                     .OrderByDescending(x => x.Key) //order groups
                     .SelectMany(g => g.OrderBy(x => x)) //order items in each group
                     .ToList();
                //Debug
                JsonResult autoData = new JsonResult(result);
                return Json(result);
            }
            return Json(null);

        }
        /// <summary>
        /// Load the XML Document from a relative path and cache the serialized model for searching
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<string> AutoSuggestCourseName(string search)
        {
            var searchTerms = _fileHelper.LoadSynonyms();

            bool found = false;

            foreach(XmlNode nData in searchTerms.GetElementsByTagName("expansion"))
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

            //now check for common misspellings
            foreach (XmlNode nData in searchTerms.GetElementsByTagName("replacement"))
            {
                foreach (XmlNode nChilddata in nData.SelectNodes(".//pat"))
                {
                    //if the pat node has the search text return all sub nodes
                    if (nChilddata.InnerText.ToUpper().Contains(search))
                    {
                        foreach (XmlNode nSubdata in nData.SelectNodes(".//sub"))
                        {
                            yield return nSubdata.InnerText;
                        }
                    }

                }
            }
           
          
        }

    }
    [Serializable, XmlRoot("thesaurus")]
    public class Thesaurus
    {
        [XmlArray("Expansion")]
        public List<string> Expansion { get; set; }
    }
    public class Expansion
    {
        [XmlArray("Sub")]
        public List<string> Sub { get; set; }
    }

}