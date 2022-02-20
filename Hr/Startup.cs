using DNTCaptcha.Core;
using Hr.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using MyTrips.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;






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
            // Set Application scope Temp Path
            var tempPath = @"C:\Safe\Location\";
            // On linux /tmp is a good choice

<<<<<<< HEAD
            Environment.SetEnvironmentVariable("TEMP", tempPath);
            Environment.SetEnvironmentVariable("TMP", tempPath);
            services.AddJsReport(new LocalReporting().Configure(cfg =>
            {
                cfg.BaseUrlAsWorkingDirectory();
                cfg.TempDirectory = tempPath;
                return cfg;
            }).UseBinary(JsReportBinary.GetBinary()).KillRunningJsReportProcesses().AsUtility().Create());
=======

>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4
            //services.ConfigureDataProtection(dp =>
            //{
            //    dp.PersistKeysToFileSystem(new DirectoryInfo(@"c:\keys"));
            //    dp.SetDefaultKeyLifetime(TimeSpan.FromDays(14));
            //});
            //services.AddAuthentication("CookieAuthentication")
            //    .AddCookie("CookieAuthentication", config =>
            //    {
            //        config.Cookie.Name = "UserLoginCookie"; // Name of cookie   
            //        /* config.LoginPath = "/Login/UserLogin";*/ // Path for the redirect to user login page  
            //     });


            //services.AddAuthorization(config =>
            //{
            //    var userAuthPolicyBuilder = new AuthorizationPolicyBuilder();
            //    config.DefaultPolicy = userAuthPolicyBuilder
            //                        .RequireAuthenticatedUser()
            //                        .RequireClaim(ClaimTypes.DateOfBirth)
            //                        .Build();
            //});
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = "Bearer";
            services.AddTransient<Services.IMailService, Services.MailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            //});
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
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



            //        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{
            //    options.LoginPath = new PathString("/Account/Index");
            //});
            //services.AddAuthentication(IISDefaults.AuthenticationScheme);
            //services.AddAuthentication(IISDefaults.AuthenticationScheme);
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            //    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //   .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //options =>
            //{
            //    options.LoginPath = new PathString("/Account/show");
            //    options.AccessDeniedPath = new PathString("/Account/Logout");
            //});


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

        //    services.AddDataProtection()
        //.PersistKeysToFileSystem(new DirectoryInfo(@"bin\debug\configuration"))
        //.ProtectKeysWithDpapi()
        //.SetDefaultKeyLifetime(TimeSpan.FromDays(10));

            services.AddDataProtection();
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDbContext<hrContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("hr"));
               
                //Options.UseOracle(Configuration.GetConnectionString("ora"));


            },ServiceLifetime.Transient
            );
            //services.AddDbContext<hrContext>(options =>
            //           options.UseSqlServer(Configuration.GetConnectionString("hr")),
            //ServiceLifetime.Transient);
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Identity/Account/Login";
            //});
            //services.AddAuthentication("CookieAuth")
            //   .AddCookie("CookieAuth", config =>
            //   {
            //       config.Cookie.Name = "default";
            //       config.LoginPath = "/Account/Index";
            //   });

            // Change max-age to a longer period (1 year at least) after you are confident with your configuration
            //services.Configure<HstsOptions>(options =>
            //{
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(360);
            //});

            services.AddAuthentication("Sys-Id")
             .AddCookie("Sys-Id", configureOptions =>
             {
                 configureOptions.Cookie.Name = "Sys-Id.Cookie";
             });
            //
            //          services.AddDNTCaptcha(options =>
            //    options.UseCookieStorageProvider()
            //        .ShowThousandsSeparators(false)
            //);


            services.AddDNTCaptcha(options =>
            {
                options.UseSessionStorageProvider()// -> It doesn't rely on the server or client's times. Also it's the safest one.
                //options.UseMemoryCacheStorageProvider()// -> It relies on the server's times. It's safer than the CookieStorageProvider.
                //options.UseCookieStorageProvider(SameSiteMode.Strict) // -> It relies on the server and client's times. It's ideal for scalability, because it doesn't save anything in the server's memory.
                                                                      // .UseDistributedCacheStorageProvider() // --> It's ideal for scalability using `services.AddStackExchangeRedisCache()` for instance.
                                                                      // .UseDistributedSerializationProvider()

                // Don't set this line (remove it) to use the installed system's fonts (FontName = "Tahoma").
                // Or if you want to use a custom font, make sure that font is present in the wwwroot/fonts folder and also use a good and complete font!
                //.UseCustomFont(Path.Combine(_env.WebRootPath, "fonts", "IRANSans(FaNum)_Bold.ttf")) // This is optional.
                .AbsoluteExpiration(minutes: 1)
                .ShowThousandsSeparators(false)
                .WithNoise(pixelsDensity: 25, linesCount: 3)
                .WithEncryptionKey("This is my secure key!")
                //.InputNames(// This is optional. Change it if you don't like the default names.
                //    new DNTCaptchaComponent
                //    {
                //        CaptchaHiddenInputName = "DNTCaptchaText",
                //        CaptchaHiddenTokenName = "DNTCaptchaToken",
                //        CaptchaInputName = "DNTCaptchaInputText"
                //    })
                //.Identifier("dntCaptcha")// This is optional. Change it if you don't like its default name.
                ;
            });


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
            
            app.UseSession();
            app.UseRouting();
            app.UseRequestLocalization();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {

                //OnPrepareResponse = x =>
                //{
                //    if (x.Context.User.Identity.IsAuthenticated)
                //    {
                //        return;
                //    }

                //    x.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //    // Append following 2 lines to drop body from static files middleware!
                //    x.Context.Response.ContentLength = 0;
                //    x.Context.Response.Body = Stream.Null;
                //    x.Context.Response.Headers.Add("Cache-Control", "no-store");


                //    // Can redirect to any URL where you prefer.
                //    // x.Context.Response.Redirect("/")
                //}


            });

            //app.UseStaticFiles();





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
