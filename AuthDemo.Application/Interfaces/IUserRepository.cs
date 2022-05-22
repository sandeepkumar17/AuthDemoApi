using AuthDemo.Core.Entities;

namespace AuthDemo.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> AuthenticateUser(string username, string password);
    }
}
