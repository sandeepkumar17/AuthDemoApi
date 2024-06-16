namespace AuthDemo.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}