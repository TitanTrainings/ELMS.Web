using ELMS.API.Repositories;
using ELMS.API.Repository;
using ELMS.API.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ELMS.API.Utility
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependecyInjectionServices(this IServiceCollection services)
        {
            // Register your custom service here
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
