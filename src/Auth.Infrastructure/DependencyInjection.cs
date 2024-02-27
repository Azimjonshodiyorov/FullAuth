using Auth.Infrastructure.DbContexts;
using Auth.Infrastructure.Repositories;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration )
        {
            services.AddScoped<IUserRepository , UserRepository>();
            services.AddScoped<IProductRepository , ProductRepository>();
            services.AddScoped<IRoleRepsoitory , RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRefreshTokenRepository , RefreshTokenRepository>();
            services.AddScoped<IUserRoleRepository , UserRoleRepository>();
            services.AddScoped<IPermissionRepository , PermissionRepository>();

           

            return services;
        }
    }
}
