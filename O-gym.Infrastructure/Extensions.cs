using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O_gym.Infrastructure.EF;

namespace O_gym.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);

            return services;
        }
    }
}
