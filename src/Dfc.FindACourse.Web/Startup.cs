using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dfc.FindACourse.Web
{
    public class Startup
    {
        FileHelper _filehelper;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton(Configuration);
            //??
            int tribalPerPage = int.TryParse(Configuration["Tribal:PerPage"], out tribalPerPage) ? tribalPerPage : 0;

            services.AddSingleton(typeof(ICourseDirectoryServiceConfiguration), 
                new CourseDirectoryServiceConfiguration(
                    Configuration["Tribal:ApiKey"],
                    tribalPerPage));

            services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<App>(Configuration.GetSection("App"));
            services.AddScoped<ICourseDirectoryService, CourseDirectoryService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddApplicationInsightsTelemetry();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMemoryCache cache, TelemetryClient telemetryClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CourseDirectory}/{action=Index}/{id?}");
            });
            //Now download the configuration from storage and cache
            DownloadConfig(cache, telemetryClient).Wait();
        }

        private async Task DownloadConfig(IMemoryCache cache, TelemetryClient telemetryClient)
        {
            try
            {
                _filehelper = new FileHelper(Configuration, cache, telemetryClient);
                await _filehelper.DownloadSynonymFile();
                await _filehelper.DownloadConfigFiles();
            }
            catch(Exception ex)
            {
                telemetryClient.TrackException(ex,
                    new Dictionary<string, string>()
                      {
                         { "DownloadConfig", "Exception" }
                     });
            }
            
        }
    }
}
