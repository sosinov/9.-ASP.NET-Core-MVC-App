using _9AspNetCoreWebAppMVC.Models;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task Add(Course course);
        Task<Course> Update(int id, Course newCourse);
        Task Delete(int id);
        Task<IEnumerable<Group>> GetCourseGroups(int id);

    }
}
