using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WdprPretparkDenhaag.Models;


namespace WdprPretparkDenhaag.Data
{
    public class PretparkContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Bezoeker> Bezoekers { get; set; }
        public DbSet<Planning> Planningen { get; set; }
        public DbSet<Tijdslot> Tijdsloten { get; set; }

        public PretparkContext(DbContextOptions<PretparkContext> options) : base(options)
        {
            
        }
        


    }

}