using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;

[assembly: HostingStartup(typeof(NTU_FYP_PEAR_CORE_20.Areas.Identity.IdentityHostingStartup))]
namespace NTU_FYP_PEAR_CORE_20.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {

            builder.ConfigureServices((context, services) => {
                /*
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("LocalDb")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();*/
            });
        }
    }
}