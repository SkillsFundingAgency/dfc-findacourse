using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dfc.FindACourse.Web.Models;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dfc.FindACourse.Services.CourseDirectory;

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        private readonly ICourseDirectoryService _courseDirectoryService;

        public CourseDirectoryController(ICourseDirectoryService courseDirectoryService)
        {
            _courseDirectoryService = courseDirectoryService;
        }

        // GET: CourseDirectory
        public ActionResult Index()
        {
            return View();
        }

        // GET: CourseDirectory
        public ActionResult CourseSearchResult([FromQuery] CourseSearchRequestModel requestModel)
        {
            var criteria = new CourseSearchCriteria(requestModel.Course);
            var result = _courseDirectoryService.CourseSearch(criteria, new PagingOptions(SortBy.Relevance, 1, 10));

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

        public JsonResult AutoAuggest(string parm)
        {
            var result = AutoSuggestCourseName(parm.ToUpper()).GroupBy(x => x.StartsWith(parm.ToUpper()))
                 .OrderByDescending(x => x.Key) //order groups
                 .SelectMany(g => g.OrderBy(x => x)) //order items in each group
                 .ToList();
            JsonResult autoData = new JsonResult(result);

            return autoData;
        }
        /// <summary>
        /// Load the XML Document from a relative path and cache the serialized model for searching
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<string> AutoSuggestCourseName(string search)
        {
            XmlDocument searchTerms = new XmlDocument();
            searchTerms.Load("Data\\tsenu.xml");

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