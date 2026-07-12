using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Entities.Products;
using SimpleShop.Domain.Models;
using SimpleShop.Domain.Repository;
using SimpleShop.Infrastructure.Context;
using SimpleShop.Infrastructure.Queries;
using SimpleShop.Infrastructure.Repository;
using SimpleShop.Infrastructure.Repository.UoW;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseInMemoryDatabase("TestDb"));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IRepository<Product>, PorductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();

        return services;
    }

    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddScoped<IProductQueryService, ProductQueryService>();

        return services;
    }
}