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
using WdprPretparkDenhaag.Data;

namespace WdprPretparkDenhaag
{
    public class Program
    {

        public static void Main(string[] args)
        {
          var builder = CreateHostBuilder(args).Build();
           using (var scope = builder.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                
                Attractie attractie = new Attractie();
                attractie.Naam = "tahir";
                attractie.AngstFactor = 2;
                var roleManager = scope.ServiceProvider.GetRequiredService<PretparkContext>();
                roleManager.Attracties.Add(attractie);
                roleManager.SaveChanges();
               
                
                
                
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
