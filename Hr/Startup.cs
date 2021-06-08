using Hr.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTrips.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Hr
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<MvcViewOptions>(options =>
            {
                // Disable hidden checkboxes
                options.HtmlHelperOptions.CheckBoxHiddenInputRenderMode = CheckBoxHiddenInputRenderMode.None;
            });
            services.ConfigureRequestLocalization();
            services.AddMemoryCache();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //    //options.ExcludedHosts.Add("example.com");
            //    //options.ExcludedHosts.Add("www.example.com");
            //});

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});

            // IWebHostEnvironment (stored in _env) is injected into the Startup class.
            //if (!env.IsDevelopment())
            //{
            //    services.AddHttpsRedirection(options =>
            //    {
            //        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
            //        options.HttpsPort = 443;
            //    });
            //}

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            //});


            services.AddControllersWithViews();
            services.AddSession();
            services.AddDbContext<hrContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("hr"));
               
                //Options.UseOracle(Configuration.GetConnectionString("ora"));


            }
            );
            // Change max-age to a longer period (1 year at least) after you are confident with your configuration
            //services.Configure<HstsOptions>(options =>
            //{
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(360);
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {       
               
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
              

                //app.UseExceptionHandler("/Home/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            //app.UseDeveloperExceptionPage();
            //app.UseDatabaseErrorPage();
            //app.UseMigrationsEndPoint();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseRequestLocalization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
