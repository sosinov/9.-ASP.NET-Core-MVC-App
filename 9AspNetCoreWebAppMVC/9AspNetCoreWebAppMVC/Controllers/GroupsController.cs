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
    public class GroupsController : Controller
    {
        private readonly IGropsService _service;

        public GroupsController(IGropsService service)
        {
            _service = service;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var groupDetails = await _service.GetById(id);
            if (groupDetails == null)
            {
                return View("NotFound");
            }
            return View(groupDetails);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CourceId")] Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }
            await _service.Add(group);
            return RedirectToAction(nameof(Index));
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var groupDetails = await _service.GetById(id);
            if (groupDetails == null)
            {
                return View("NotFound");
            }
            return View(groupDetails);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CourceId")] Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }
            await _service.Update(id, group);
            return RedirectToAction(nameof(Index));
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var groupDetails = await _service.GetById(id);
            if (groupDetails == null)
            {
                return View("NotFound");
            }
            if (!_service.CheckGroup(id))
            {
                return View("GroupContsainsStudents");
            }
            return View(groupDetails);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupDetails = await _service.GetById(id);
            if (groupDetails == null)
            {
                return View("NotFound");
            }            
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetGroupStudents(int id)
        {
            var groupStudents = await _service.GetGroupStudents(id);
            if (groupStudents == null)
            {
                return View("NotFound");
            }
            return View(groupStudents);
        }
        /*
        private bool GroupExists(int id)
        {
          return _context.Group.Any(e => e.Id == id);
        }*/
    }
}
