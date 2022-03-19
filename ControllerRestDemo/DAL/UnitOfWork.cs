namespace ControllerRestDemo.DAL
{
    public class UnitOfWork
    {
        private UserContext _userContext;

        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new UserRepository(_userContext);
                }

                return _userRepository;
            }
        }

        public IGroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository is null)
                {
                    _groupRepository = new GroupRepository(_userContext);
                }

                return _groupRepository;
            }
        }

        public UnitOfWork(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Save()
        {
            _userContext.SaveChanges();
        }
    }
}
