using ControllerRestDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerRestDemo.DAL
{
    public class GroupRepository : IGroupRepository
    {
        private readonly UserContext _userContext;
        
        public GroupRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Create(Group group)
        {
            _userContext.Groups.Add(group);
        }

        public ICollection<Group>? GetAllGroups()
        {
            return _userContext.Groups.ToList();
        }

        public ICollection<User>? GetGroupUsers(int id)
        {
            var group = _userContext.Groups.Include(g => g.Users).FirstOrDefault(g => g.Id == id);
            if (group is null)
                return null;

            return group.Users;
        }

        public Group? GetGroup(int id)
        {
            return _userContext.Groups.FirstOrDefault(g => g.Id == id);
        }

        public bool UpdateGroup(int id, Group group)
        {
            var existingGroup = _userContext.Groups.FirstOrDefault(u => u.Id == id);
            if (existingGroup is null)
            {
                return false;
            }

            group.Id = existingGroup.Id;

            existingGroup = group;

            return true;
        }

        public bool UpdateGroupName(int id, string name)
        {
            var existingGroup = _userContext.Groups.FirstOrDefault(u => u.Id == id);
            if (existingGroup is null)
            {
                return false;
            }

            existingGroup.Name = name;

            return true;
        }

        public bool AddUserToGroup(int groupId, int userId)
        {
            var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == userId);
            if (existingUser is null)
            {
                return false;
            }

            var existingGroup = _userContext.Groups.FirstOrDefault(g => g.Id == groupId);
            if (existingGroup is null)
            {
                return false;
            }

            existingGroup.Users.Add(existingUser);

            return true;
        }

        public bool DeleteGroup(int id)
        {
            var existingGroup = _userContext.Groups.FirstOrDefault(u => u.Id == id);
            if (existingGroup is null)
            {
                return false;
            }
            _userContext.Groups.Remove(existingGroup);

            return true;
        }
        
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
