using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dfc.FindACourse.Web.Controllers
{
    public class CourseDirectoryController : Controller
    {
        // GET: CourseDirectory
        public ActionResult Index()
        {
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
    }
}