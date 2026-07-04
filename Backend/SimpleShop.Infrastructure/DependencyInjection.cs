using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Infrastructure.Context;

namespace SimpleShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseInMemoryDatabase("TestDb"));

        return services;
    }
}