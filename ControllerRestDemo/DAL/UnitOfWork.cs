namespace ControllerRestDemo.DAL
{
    public class UnitOfWork : IDisposable
    {
        private UserContext _userContext;

        private IUserRepository _userRepository;

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

        public UnitOfWork(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Save()
        {
            _userContext.SaveChanges();
        }

        public void Dispose()
        {
            _userContext.Dispose();
            _userRepository.Dispose();
        }
    }
}
