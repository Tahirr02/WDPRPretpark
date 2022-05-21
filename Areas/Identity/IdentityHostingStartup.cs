using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WdprPretparkDenhaag.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WdprPretparkDenhaag.Areas.Identity.IdentityHostingStartup))]
namespace WdprPretparkDenhaag.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WdprPretparkDenhaagIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WdprPretparkDenhaagIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WdprPretparkDenhaagIdentityDbContext>();
            });
        }
    }
}