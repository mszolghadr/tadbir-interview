using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using tadbir.Repository;
using tadbir.Service.DTOs;
using tadbir.Service.Implementations;
using tadbir.Service.Interfaces;

namespace tadbir.Service
{

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddRepositoryConnector();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProductService, ProductService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = false;
                mc.AddProfile(new MapperProfile());
            });
            // IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton<IMapper>(sp => mappingConfig.CreateMapper());

            return services;
        }
    }
}