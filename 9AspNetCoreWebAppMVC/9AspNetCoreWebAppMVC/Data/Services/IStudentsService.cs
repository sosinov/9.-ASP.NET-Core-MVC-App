using _9AspNetCoreWebAppMVC.Models;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Add(Student student);
        Task<Student> Update(int id, Student newStudent);
        Task Delete(int id);
    }
}
