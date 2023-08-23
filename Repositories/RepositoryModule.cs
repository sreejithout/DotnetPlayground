using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repositories.Interfaces;

namespace Repositories
{
    public static class RepositoryModule
    {
        /// <summary>
        /// Extension method to inject Dependencies from this project
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            // Transient: created each time they are requested for.
            // Scoped: created once in the entire request scope.
            // Singleton: created once in the application lifetime.
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
