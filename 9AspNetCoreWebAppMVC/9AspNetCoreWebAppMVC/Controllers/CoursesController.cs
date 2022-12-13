using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _9AspNetCoreWebAppMVC.Data;
using _9AspNetCoreWebAppMVC.Models;
using _9AspNetCoreWebAppMVC.Data.Services;

namespace _9AspNetCoreWebAppMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;

        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var courseDetails = await _service.GetById(id);
            if (courseDetails == null)
            {
                return View("NotFound");
            }
            return View(courseDetails);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            await _service.Add(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var courseDetails = await _service.GetById(id);
            if (courseDetails == null)
            {
                return View("NotFound");
            }
            return View(courseDetails);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            await _service.Update(id, course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var courseDetails = await _service.GetById(id);
            if (courseDetails == null)
            {
                return View("NotFound");
            }
            return View(courseDetails);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseDetails = await _service.GetById(id);
            if (courseDetails == null)
            {
                return View("NotFound");
            }

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetCourseGroups(int id)
        {
            var courseGroups = await _service.GetCourseGroups(id);
            if (courseGroups == null)
            {
                return View("NotFound");
            }
            return View(courseGroups);
        }

        /*
        private bool CourseExists(int id)
        {
          return _context.Course.Any(e => e.Id == id);
        }*/
    }
}
