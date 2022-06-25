using BlackBoard.WebApi.Context;
using BlackBoard.WebApi.Extensions;
using BlackBoard.WebApi.Intrerface;
using BlackBoard.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBoard.WebApi
{
    /// <summary>
    /// Startup class of the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="configuration">IConfiguration configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration configuration property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MemberDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MemberDbConnection")));
            services.AddScoped<IMemberService, MemberService>();
            //services.AddSpaStaticFiles(configuration => { configuration.RootPath = "FrontEnd/dist"; });
            services.AddSwaggerConfiguration();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder app</param>
        /// <param name="env">IWebHostEnvironment env)</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowAnyOrigin");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerConfig();

            //app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "FrontEnd";
            //});
        }
    }
}
