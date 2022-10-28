using ControllerRestDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerRestDemo.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Create(User user)
        {
            _userContext.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userContext.Users.ToList();
        }

        public User? GetUser(int id)
        {
            return _userContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Group>? GetUserGroups(int id)
        {
            var user = _userContext.Users.Include(u=>u.Groups).FirstOrDefault(u=>u.Id == id);
            if(user is null)
                return null;

            return user.Groups;
        }

        public bool UpdateUser(int id, User user)
        {
            var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            user.Id = existingUser.Id;

            existingUser = user;

            return true;
        }

        public bool UpdateUserName(int id, string name)
        {
            var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.Name = name;

            return true;
        }

        public bool UpdateUserEmail(int id, string email)
        {
            var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.Email = email;

            return true;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = _userContext.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }
            _userContext.Users.Remove(existingUser);

            return true;
        }
        
    }
}
