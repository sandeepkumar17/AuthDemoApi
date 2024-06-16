using AuthDemo.Application.Interfaces;
using AuthDemo.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemo.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}