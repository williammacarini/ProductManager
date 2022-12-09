using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Infra.Data.Context;
using ProductManager.Infra.Data.Repositories;
using ProductManager.Service.DTOs;
using ProductManager.Service.Mapper;
using ProductManager.Service.Services;
using ProductManager.Service.Services.Interfaces;

namespace ProductManger.Infra.CrossCutting.IoC
{
    public static class RegisterDependencies
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductManagerContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Connection")));

            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddSingleton(GetMappers());

            services.AddScoped<IProductService, ProductService>();
        }

        public static IMapper GetMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
