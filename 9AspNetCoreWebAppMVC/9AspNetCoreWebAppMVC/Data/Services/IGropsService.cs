using _9AspNetCoreWebAppMVC.Models;

namespace _9AspNetCoreWebAppMVC.Data.Services
{
    public interface IGropsService
    {
        Task<IEnumerable<Group>> GetAll();
        Task<Group> GetById(int id);
        Task Add(Group group);
        Task<Group> Update(int id, Group newGroup);
        Task Delete(int id);
        Task<IEnumerable<Student>> GetGroupStudents(int id);
        bool CheckGroup(int id);
    }
}
