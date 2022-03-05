using ApplicantsTask.Application.Validations;
using ApplicantsTask.Infra.IOC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SharedKernal.Middlewares;

namespace ApplicantsTask.Presentation.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.Initialize();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApplicantInputValidation>(lifetime: ServiceLifetime.Scoped))
                 .AddControllersAsServices();
            services.Initialize();
            RegisterServices(services, _configuration);

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
          
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Initialize();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void RegisterServices(IServiceCollection services, IConfiguration _configuration)
        {
            DependencyContainer.RegisterServices(services, _configuration);

        }
    }
}
