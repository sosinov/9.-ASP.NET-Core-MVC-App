using _9AspNetCoreWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly _9AspNetCoreWebAppMVCContext _context;

        public StudentsService(_9AspNetCoreWebAppMVCContext context) 
        {
            _context= context;
        }
        public async Task Add(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Student.FirstOrDefaultAsync(x => x.Id == id);
            _context.Student.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var result = await _context.Student.Include(n => n.Group).ToListAsync();
            return result;
        }

        public async Task<Student> GetById(int id)
        {
            var result = await _context.Student.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Student> Update(int id, Student newStudent)
        {
            _context.Update(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }
    }
}
