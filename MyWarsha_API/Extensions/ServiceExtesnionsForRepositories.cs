using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Repositories;

namespace MyWarsha_API.Extensions
{
    public static class ServiceExtesnionsForRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarInfoRepository, CarInfoRepository>();
            services.AddScoped<ICarMakerRepository, CarMakerRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<ICarGenerationRepository, CarGenerationRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarImageRepository, CarImageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            

            return services;
        }
    }
}