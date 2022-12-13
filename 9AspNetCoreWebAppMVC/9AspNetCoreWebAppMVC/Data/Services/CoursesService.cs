using _9AspNetCoreWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public class CoursesService:ICoursesService
    {
        private readonly _9AspNetCoreWebAppMVCContext _context;

        public CoursesService(_9AspNetCoreWebAppMVCContext context)
        {
            _context = context;
        }

        public async Task Add(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);
            _context.Course.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await _context.Course.ToListAsync();
            return result;
        }

        public async Task<Course> GetById(int id)
        {
            var result = await _context.Course.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Course> Update(int id, Course newCourse)
        {
            _context.Update(newCourse);
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<IEnumerable<Group>> GetCourseGroups(int id)
        {
            var result = await _context.Group.Where(x => x.CourceId == id).Include(n => n.Course).ToListAsync();
            return result;
        }
    }
}
