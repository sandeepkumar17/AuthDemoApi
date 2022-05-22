using AuthDemo.Application.Interfaces;
using AuthDemo.Core.Entities;
using AuthDemo.Infrastructure.Sql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AuthDemo.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        #region ===[ Private Members ]=============================================================
        
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly IConfiguration configuration;

        #endregion

        #region ===[ Constructor ]=================================================================

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region ===[ IUserRepository Methods ]=====================================================

        public async Task<List<User>> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var users = await connection.QueryAsync<User>(Queries.AllUsers);

                return users.ToList();
            }
        }

        public async Task<User> GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var user = (await connection.QueryAsync<User>(Queries.UserById, new { id = id })).SingleOrDefault();

                return user;
            }
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var user = (await connection.QueryAsync<User>(Queries.AuthenticateUser
                    , new { UserName = username, Password= password })).FirstOrDefault();

                return user;
            }
        }

        #endregion
    }
}
