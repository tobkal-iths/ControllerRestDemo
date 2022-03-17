using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UserContext _userContext;

        private readonly IDictionary<int, User> _users;

        private int _id = 2;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Create(User user)
        {
            _userContext.Users.Add(user);
        }

        public ICollection<User> GetAllUsers()
        {
            return _users.Values;
        }

        public User? GetUser(int id)
        {
            if (!_users.Keys.Contains(id))
            {
                return null;
            }

            return _users[id];
        }

        public bool UpdateUser(int id, User user)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users[id] = user;

            return true;
        }

        public bool UpdateUserName(int id, string name)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users[id].Name = name;

            return true;
        }

        public bool UpdateUserEmail(int id, string email)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users[id].Email = email;

            return true;
        }

        public bool DeleteUser(int id)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users.Remove(id);

            return true;
        }
        
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
