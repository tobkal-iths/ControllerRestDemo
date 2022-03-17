using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL;

public interface IUserRepository : IDisposable
{
    void Create(User user);
    ICollection<User> GetAllUsers();
    User? GetUser(int id);
    bool UpdateUser(int id, User user);
    bool UpdateUserName(int id, string name);
    bool UpdateUserEmail(int id, string email);
    bool DeleteUser(int id);
}