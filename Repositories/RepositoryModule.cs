using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;

namespace Repositories
{
    public static class RepositoryModule
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
