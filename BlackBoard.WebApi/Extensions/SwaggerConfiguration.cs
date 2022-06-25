using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace BlackBoard.WebApi.Extensions
{
    /// <summary>
    /// Swagger Configuration extended class
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Add Swagger Configuration
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection serviceCollection)</param>
        public static void AddSwaggerConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Black Board Web APIs",
                    Version = "V1",
                    Description = "Web API to provide end points to UI or Client, built in .Net Core 3.1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Ram Vinay Kumar",
                        Email = "ramvinaykumar@hotmail.com"
                    }
                });
                swagger.CustomSchemaIds(x => x.FullName);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Use Swagger Config
        /// </summary>
        /// <param name="app">IApplicationBuilder app</param>
        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/V1/swagger.json", "Black Board Web APIs");
                ui.RoutePrefix = String.Empty;
                ui.DefaultModelExpandDepth(0);
            });
        }
    }
}
