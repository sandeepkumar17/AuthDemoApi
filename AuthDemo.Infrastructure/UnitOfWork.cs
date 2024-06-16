using AuthDemo.Application.Interfaces;

namespace AuthDemo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }

        public IUserRepository Users { get; set; }
    }
}