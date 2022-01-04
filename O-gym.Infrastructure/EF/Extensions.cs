using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O_gym.Infrastructure.EF.Contexts;
using O_gym.Infrastructure.EF.ProviderConfigs;

namespace O_gym.Infrastructure.EF
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlServerConfig = new SqlServerConfiguration();
            configuration.GetSection(nameof(SqlServerConfiguration)).Bind(sqlServerConfig);

            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseSqlServer(sqlServerConfig.ConnectionString));

            //services.AddDbContext<WriteDbContext>(ctx =>
            //    ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}
