using Auth.Domain.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureRepositoriesByAssembly(this IServiceCollection serviceCollection, Assembly assembly)
        {
            var repositories = assembly.GetTypes()
                .Where(x => x.GetCustomAttribute<IsRepositoryAttribute>() is not null && x.IsClass &&
                            x.GetInterfaces().Length != 0);

            foreach (var repository in repositories)
            {
                serviceCollection.AddScoped(repository.GetInterfaces().FirstOrDefault(x =>
                    x.Name.EndsWith(repository.Name))!, repository);
            }
        }


        public static void ConfigureServicesByAssembly(this IServiceCollection serviceCollection, Assembly assembly)
        {
            var services = assembly.GetTypes()
                .Where(x => x.GetCustomAttribute<IsServiceAttribute>() is not null && x.IsClass &&
                            x.GetInterfaces().Length != 0);

            foreach (var service in services)
            {
                serviceCollection.AddScoped(service.GetInterfaces().FirstOrDefault()!, service);
            }
        }
    }
}
