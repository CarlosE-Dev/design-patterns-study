using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Domain.Models;
using DesignPatterns.Infra.Facade;
using DesignPatterns.Infra.Repositories;
using DesignPatterns.Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DesignPatterns.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatterns", Version = "v1" });
            });

            services.AddSingleton<SingletonContainer>();

            // We need to have only one instance of this because we are using an "in memory repository"
            // we dont want a new instance of the person's list(DB Mock)
            services.AddSingleton<IPersonRepository, PersonRepository>();

            services.AddTransient<IPersonActions, PersonActions>();

            // Configuration to get simulated information from AppSettings.json
            services.Configure<BankOptions>(Configuration.GetSection("BankOptions"));

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesignPatterns v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
