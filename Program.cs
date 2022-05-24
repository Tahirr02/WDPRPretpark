using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using WdprPretparkDenhaag.Areas.Identity.Data;


namespace WdprPretparkDenhaag
{
    public class Program
    {

        public static void Main(string[] args)
        {
          var builder = CreateHostBuilder(args).Build();
           using (var scope = builder.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                using (var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>())
                {
                    var roles = new string[] { "Admin", "Bezoeker", "mohamed" };
                    foreach (var role in roles)
                        if (!roleManager.RoleExistsAsync(role).Result)
                            roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
                // Attractie attractie = new Attractie();
                // attractie.Naam = "mo";
                // attractie.AngstFactor = 2;
                // var roleManager = scope.ServiceProvider.GetRequiredService<WdprPretparkDenhaagIdentityDbContext>();
                // roleManager.Attracties.Add(attractie);
                // roleManager.SaveChanges();
               
                
                
                
            }
            
          builder.Run();
            
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
