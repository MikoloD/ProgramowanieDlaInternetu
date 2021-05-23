using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgApplication.Areas.Identity.Data;
using RpgApplication.Models;

[assembly: HostingStartup(typeof(RpgApplication.Areas.Identity.IdentityHostingStartup))]
namespace RpgApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedEmail = false)   
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DatabaseContext>();
                
            });
        }
    }
}