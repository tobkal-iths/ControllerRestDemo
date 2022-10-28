using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL;

public interface IUserRepository
{
    bool Create(User user);
    IEnumerable<User> GetAllUsers();
    User? GetUser(int id);
    ICollection<Group>? GetUserGroups(int id);
    bool UpdateUser(int id, User user);
    bool UpdateUserName(int id, string name);
    bool UpdateUserEmail(int id, string email);
    bool DeleteUser(int id);
}