using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Services.CourseDirectory;
using Dfc.FindACourse.Services.FindACourse;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Services.Postcode;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.Middleware;
using Dfc.FindACourse.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
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
            services.AddSingleton(typeof(ICourseAPIConfiguration),
                new CourseAPIConfiguration(
                    Configuration["CourseAPI:ApiKey"],
                    Configuration["CourseAPI:APIAddress"]));

            services.AddSingleton(typeof(IFindACourseConfiguration),
                new FindACourseConfiguration(
                    Configuration["FindACourse:ApiKey"],
                    tribalPerPage,
                    Configuration["FindACourse:APIAddress"],
                    Configuration["FindACourse:UserName"],
                    Configuration["FindACourse:Password"]));

            services.AddScoped<ServiceInterface>((provider) =>
                new ServiceInterfaceClient(
                    new ServiceInterfaceClient.EndpointConfiguration(),
                    Configuration["Tribal:APIAddress"]));

            services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<App>(Configuration.GetSection("App"));
            services.Configure<App>(Configuration.GetSection("Storage"));
            services.Configure<App>(Configuration.GetSection("Tribal"));
            //NCS Find A Course
            services.Configure<App>(Configuration.GetSection("FindACourse"));

            services.AddSingleton(typeof(IPostcodeServiceConfiguration),
                new PostcodeServiceConfiguration(Configuration["Postcodes.Io:ApiBaseUrl"]));

            services.AddScoped<ITelemetryClient, TelemetryClientAdapter>();
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
            services.AddCorrelationId();

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

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                await next();
            });

            app.UseCorrelationId(new CorrelationIdOptions());

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

            // MA - This is here for performance logging andtroubleshooting this is NOT needed for functionality
            ApiHttpRequestAndLog(env, telemetryClient);
        }

        private void ApiHttpRequestAndLog(IHostingEnvironment env, ITelemetryClient telemetryClient)
        {
            try
            {
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: {nameof(Environment.MachineName)} = {Environment.MachineName}");
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: {nameof(env.EnvironmentName)} = {env.EnvironmentName}");
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: {nameof(env.ApplicationName)} = {env.ApplicationName}");

                var sw = new Stopwatch();
                var uri = new Uri(Configuration["Tribal:APIAddress"]);
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: {nameof(uri.Host)} = {uri.Host}");
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: Address = {uri.OriginalString}");

                using (var httpClient = new HttpClient())
                {
                    telemetryClient.TrackEvent($"Start Up Api HttpRequest: Started at = {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
                    sw.Start();
                    var statusCode = httpClient.GetAsync(uri).Result.StatusCode;
                    sw.Stop();
                    telemetryClient.TrackEvent($"Start Up Api HttpRequest: Ended at = {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}");
                    telemetryClient.TrackEvent($"Start Up Api HttpRequest: Http Status Code = {statusCode}");
                    telemetryClient.TrackEvent($"Start Up Api HttpRequest: Time taken = {sw.ElapsedMilliseconds} ms");
                }
            }
            catch (Exception e)
            {
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: exception");
                telemetryClient.TrackException(e);
            }
        }

        private void ApiPingAndLog(IHostingEnvironment env, ITelemetryClient telemetryClient)
        {

            Ping pinger = null;

            try
            {
                telemetryClient.TrackEvent($"Start Up Api HttpRequest: {nameof(Environment.MachineName)} = {Environment.MachineName}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(env.EnvironmentName)} = {env.EnvironmentName}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(env.ApplicationName)} = {env.ApplicationName}");

                var uri = new Uri(Configuration["Tribal:APIAddress"]);
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(uri.Host)} = {uri.Host}");

                pinger = new Ping();
                var reply = pinger.Send(uri.Host);
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.Address)} = {reply?.Address}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.Options.DontFragment)} = {reply?.Options?.DontFragment}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.Options.Ttl)} = {reply?.Options?.Ttl}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.RoundtripTime)} = {reply?.RoundtripTime}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.Buffer.Length)} = {reply?.Buffer?.Length}");
                telemetryClient.TrackEvent($"Start Up Api Ping: {nameof(reply.Status)} = {reply?.Status}");
            }
            catch (Exception e)
            {
                telemetryClient.TrackEvent($"Start Up Api Ping: exception");
                telemetryClient.TrackException(e);
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
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
