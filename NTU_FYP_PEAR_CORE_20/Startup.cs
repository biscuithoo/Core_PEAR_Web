using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NTU_FYP_PEAR_CORE_20.Configuration;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Repository;
using NTU_FYP_PEAR_CORE_20.Services;
using System;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace NTU_FYP_PEAR_CORE_20
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
            var cloudName = Configuration.GetValue<string>("AccountSettings:CloudName");
            var apiKey = Configuration.GetValue<string>("AccountSettings:ApiKey");
            var apiSecret = Configuration.GetValue<string>("AccountSettings:ApiSecret");

            if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Please specify Cloudinary account details!");
            }
            

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
            
            //Configuration from AppSettings
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            //Adding Athentication - JWT
            services.AddAuthentication()
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // configure database connection
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDb")));

            // provides helpful error info in development environment
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();


            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddRazorPages();

            services.AddService();
            services.AddRepository();
            // services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); }); // might not be needed
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
/*
            app.UseStatusCodePages(async context => {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                // you may also check requests path to do this only for specific methods       
                // && request.Path.Value.StartsWith("/specificPath")

                {
                    response.Redirect("/identity/account/login");
                }
            });
*/
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                                    name: "default",
                                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                                   name: "api",
                                   pattern: "{controller=api}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });
            //app.UseCors(options => options.AllowAnyOrigin()); // might not be needed
     
        }
    }
}
