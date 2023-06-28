using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using GeoLocationDemo.Infrastructure.Repositories.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;

namespace GeoLocationDemo.Infrastructure.Repositories
{
    public static class ServiceRegistration
    {
        public static void RegisterInfrastructureRepositoryServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IListsRepository, ListRepository>();
        }
    }
}