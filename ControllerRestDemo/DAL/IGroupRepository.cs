using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL;

public interface IGroupRepository
{
    void Create(Group group);
    ICollection<Group> GetAllGroups();
    Group? GetGroup(int id);
    ICollection<User> GetGroupUsers(int id);
    bool UpdateGroup(int id, Group group);
    bool UpdateGroupName(int id, string name);
    bool AddUserToGroup(int groupId, int userId);
    bool DeleteGroup(int id);
}