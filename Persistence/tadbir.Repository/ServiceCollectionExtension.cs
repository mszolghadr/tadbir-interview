using Microsoft.Extensions.DependencyInjection;
using tadbir.Repository.Interfaces;

namespace tadbir.Repository
{

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}