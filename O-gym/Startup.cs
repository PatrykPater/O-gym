using O_gym.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using O_gym.Infrastructure;

namespace O_gym
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddControllers();

            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "games-store API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerConfig = new SwaggerConfiguration();
            Configuration.GetSection(nameof(SwaggerConfiguration)).Bind(swaggerConfig);

            app.UseSwagger(option => option.RouteTemplate = option.RouteTemplate = swaggerConfig.JsonRoute);
            app.UseSwaggerUI(option => option.SwaggerEndpoint(swaggerConfig.UIEndPoint, swaggerConfig.Description));

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
