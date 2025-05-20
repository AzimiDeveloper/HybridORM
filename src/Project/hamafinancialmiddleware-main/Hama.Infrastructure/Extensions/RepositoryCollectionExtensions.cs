using Hama.Infrastructure.Repositories.Implementations;
using Hama.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hama.Infrastructure.Extensions
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Repository Base Classes
            services.AddScoped(typeof(IBaseEfRepository<>), typeof(BaseEfRepository<>));
            services.AddScoped(typeof(IBaseRepoDbRepository<>), typeof(BaseRepoDbRepository<>));


            return services;
        }
    }
}
