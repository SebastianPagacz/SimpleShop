using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Models;
using SimpleShop.Infrastructure.Context;
using SimpleShop.Infrastructure.Repository;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseInMemoryDatabase("TestDb"));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, PorductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();

        return services;
    }
}