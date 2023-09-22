using MGP.ApiDotNet6.Application.Mappers;
using MGP.ApiDotNet6.Application.Services;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using MGP.ApiDotNet6.Domain.Repositories;
using MGP.ApiDotNet6.Infra.Data.Context;
using MGP.ApiDotNet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGP.ApiDotNet6.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                     options.UseNpgsql(configuration.GetConnectionString("")));
                       
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ConfigureAutoMapper));

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            return services;
        }
    }
}
