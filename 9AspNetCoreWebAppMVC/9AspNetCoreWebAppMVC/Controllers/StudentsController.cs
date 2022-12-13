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
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;

        public StudentsController(IStudentsService service)
        {
            _service = service;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,First_Name,Last_Name")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Add(student);
            return RedirectToAction(nameof(Index));
        }

                
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var studentDetails = await _service.GetById(id);
            if (studentDetails == null) 
            { 
                return View("NotFound"); 
            }
            return View(studentDetails);
        }

        
        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var studentDetails = await _service.GetById(id);
            if (studentDetails == null)
            {
                return View("NotFound");
            }
            return View(studentDetails);
        }
        
        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,First_Name,Last_Name")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.Update(id, student);
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var studentDetails = await _service.GetById(id);
            if (studentDetails == null)
            {
                return View("NotFound");
            }
            return View(studentDetails);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDetails = await _service.GetById(id);
            if (studentDetails == null)
            {
                return View("NotFound");
            }

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool StudentExists(int id)
        {
          return _context.Student.Any(e => e.Id == id);
        }*/
    }
}
