using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services;

public static class ServiceModule
{
    /// <summary>
    /// Extension method to inject Dependencies from this project
    /// </summary>
    /// <param name="services"></param>
    public static void AddServices(this IServiceCollection services)
    {
        // Transient: created each time they are requested for.
        // Scoped: created once in the entire request scope.
        // Singleton: created once in the application lifetime.
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICustomerService, CustomerService>();
    }
}
