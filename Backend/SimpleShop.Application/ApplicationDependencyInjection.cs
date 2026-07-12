using Microsoft.Extensions.DependencyInjection;


namespace SimpleShop.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

        return services;
    }
}
