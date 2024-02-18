using Auth.Application.Interfaces;
using Auth.Application.MappingProfils;
using Auth.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();

            services.AddTransient<IUserRoleService, UserRoleService>();
            return services;
        }
    }
}
