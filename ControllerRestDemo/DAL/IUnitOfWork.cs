namespace ControllerRestDemo.DAL;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IGroupRepository GroupRepository { get; }
    void Save();
}