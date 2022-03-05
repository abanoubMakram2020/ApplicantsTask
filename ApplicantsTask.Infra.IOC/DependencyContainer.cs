using ApplicantsTask.Application.Automapper;
using ApplicantsTask.Application.ServicesImplementation;
using ApplicantsTask.Application.ServicesInterfaces;
using ApplicantsTask.Application.UnitOfWork;
using ApplicantsTask.Domain.RepositriesInterfaces;
using ApplicantsTask.Infra.Data.Context;
using ApplicantsTask.Infra.Data.Repositrories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernal.Common.Configuration;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.ResourcesReader.Message;
using SharedKernal.Middlewares.Logging;

namespace ApplicantsTask.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IApplicantService, ApplicantService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

          
            services.AddScoped<IMessageResourceReader, MessageResourceReader>();

            #region DB Contexts


            services.AddDbContext<ApplicantsTaskDBContext>(options =>
            options.UseSqlServer(DatabaseConfiguration.ApplicantsDBConnection));

            #endregion

            AutoMapperConfiguration.RegisterMappings();
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddSingleton<ILogger, Logger>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<Presenter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
