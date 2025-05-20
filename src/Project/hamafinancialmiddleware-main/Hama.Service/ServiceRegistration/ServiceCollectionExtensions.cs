using Hama.Infrastructure.Repositories.Implementations;
using Hama.Infrastructure.Repositories.Interfaces;
using Hama.Service.Implementations.Users;
using Hama.Service.Interfaces.ORM;
using Hama.Service.Interfaces.Users;
using Hama.Service.ORM;
using Microsoft.Extensions.DependencyInjection;

namespace Hama.Service.ServiceRegistration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseServiceEf<>), typeof(BaseEfService<>));
            services.AddScoped(typeof(IBaseRepoDbService<>), typeof(BaseRepoDbService<>));
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }

}
