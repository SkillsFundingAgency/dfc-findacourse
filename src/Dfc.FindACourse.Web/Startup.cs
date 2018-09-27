using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Services.Postcode;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.Services;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tribal;

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
            //??  ASB What is this doing? 
            int tribalPerPage = int.TryParse(Configuration["Tribal:PerPage"], out tribalPerPage) ? tribalPerPage : 0;

            services.AddSingleton(typeof(ICourseDirectoryServiceConfiguration), 
                new CourseDirectoryServiceConfiguration(
                    Configuration["Tribal:ApiKey"],
                    tribalPerPage,
                    Configuration["Tribal:APIAddress"]));

            services.AddSingleton<ServiceInterface>(new ServiceInterfaceClient(new ServiceInterfaceClient.EndpointConfiguration(), Configuration["Tribal:APIAddress"]));

            services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<App>(Configuration.GetSection("App"));
            services.Configure<App>(Configuration.GetSection("Storage"));
            services.Configure<App>(Configuration.GetSection("Tribal"));

            services.AddSingleton(typeof(IPostcodeServiceConfiguration),
                new PostcodeServiceConfiguration(Configuration["Postcodes.Io:ApiBaseUrl"]));

            services.AddScoped<ITelemetryClient, MyTelemetryClient>();
            services.AddScoped<ICourseDirectory, CourseDirectory>();
            services.AddScoped<ICourseSearch, CourseSearch>();
            services.AddScoped<IServiceHelper, ServiceHelper>();
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddScoped<ICourseDirectoryHelper, CourseDirectoryHelper>();

            services.AddScoped<ICourseDirectoryService, CourseDirectoryService>();
            services.AddSingleton<HttpClientHandler>(new HttpClientHandler());
            services.AddScoped<IPostcodeService, PostcodeService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddApplicationInsightsTelemetry();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMemoryCache cache, ITelemetryClient telemetryClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CourseDirectory}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();

            //Now download the configuration from storage and cache
            DownloadConfig(cache, telemetryClient).Wait();
        }


        //ASB What is this doing?
        private async Task DownloadConfig(IMemoryCache cache, ITelemetryClient telemetryClient)
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
