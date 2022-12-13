using _9AspNetCoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public class GroupsService: IGropsService
    {
        private readonly _9AspNetCoreWebAppMVCContext _context;

        public GroupsService(_9AspNetCoreWebAppMVCContext context)
        {
            _context = context;
        }

        public async Task Add(Group group)
        {
            await _context.Group.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Group.FirstOrDefaultAsync(x => x.Id == id);
            _context.Group.Remove(result);
            await _context.SaveChangesAsync();
        }

        public bool CheckGroup(int id)
        {
            var students = from g in _context.Student
                           select g;
            students = students.Where(a => a.GroupId == id);
            if (!students.ToArray().IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            var result = await _context.Group.Include(n => n.Course).ToListAsync();
            return result;
        }

        public async Task<Group> GetById(int id)
        {
            var result = await _context.Group.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Group> Update(int id, Group newGroup)
        {
            _context.Update(newGroup);
            await _context.SaveChangesAsync();
            return newGroup;
        }

        public async Task<IEnumerable<Student>> GetGroupStudents(int id)
        {
            var result = await _context.Student.Where(x => x.GroupId == id).Include(n => n.Group).ToListAsync();
            return result;
        }
    }
}
