using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WdprPretparkDenhaag.Models;

namespace WdprPretparkDenhaag.Areas.Identity.Data
{
    public class WdprPretparkDenhaagIdentityDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Bezoeker> Bezoekers { get; set; }
        public DbSet<Planning> Planningen { get; set; }
        public DbSet<Tijdslot> Tijdsloten { get; set; }
        public DbSet<PlanningItem> PlanningItems {get; set;}
        public WdprPretparkDenhaagIdentityDbContext(DbContextOptions<WdprPretparkDenhaagIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
