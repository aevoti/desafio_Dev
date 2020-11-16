using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace ApiAlunos.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
