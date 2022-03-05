using ApplicantsTask.Presentation.MVC.Helper;
using ApplicantsTask.Presentation.MVC.Services.Implementation;
using ApplicantsTask.Presentation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedKernal.Common;
using System;
using System.Net.Http.Headers;

namespace ApplicantsTask.Presentation.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var _applicantAPIConfigurations = new ApplicantAPIConfigurations();
            Configuration.Bind(nameof(ApplicantAPIConfigurations), _applicantAPIConfigurations);

            services.AddHttpClient(name: ApplicantAPIConfigurations.ServiceName, configureClient: client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(ApplicantAPIConfigurations.BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeType.ApplicationJson));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-type", MimeType.ApplicationJson);
                client.DefaultRequestHeaders.Add("accept-language", System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            });

            services.AddScoped<ICommonHandle, CommonHandle>();
            services.AddScoped<IApplicantClientService, ApplicantClientService>();
            services.AddScoped<IUserClientService, UserClientService>();
            services.AddControllersWithViews();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ApplicantClient}/{action=Index}/{id?}");
            });
        }
    }

}
