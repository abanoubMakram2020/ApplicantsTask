using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernal.Common.Configuration;
using SharedKernal.Middlewares.Swagger.Pipeline;
using System.Collections.Generic;
using System.Linq;

namespace SharedKernal.Middlewares.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string documentName, List<SwaggerVersion> version, string title, string description)
        {
            services.AddSwaggerGen(c =>
            {
                version.ForEach(v =>
                {
                    c.SwaggerDoc(v.Version, new OpenApiInfo
                    {
                        Title = $"{documentName} ({v.Version})",
                        Description = description,
                        Version = v.Version,
                    });
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());
            
                c.OperationFilter<RemoveVersionParameterFilter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = title,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new System.Collections.Generic.List<string>()
                    }
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, string documentName, string title, List<SwaggerVersion> version)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = title;
                version.ForEach(v =>
                {
                    c.SwaggerEndpoint(v.URL, $"{documentName} ({v.Version})");
                });

            });
            return app;
        }

    }
}