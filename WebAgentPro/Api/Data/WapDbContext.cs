using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAgentPro.Models;
using WebAgentPro.Api.Models;

namespace WebAgentPro.Data
{
    public class WapDbContext : IdentityDbContext<WapUser>
    {
        public WapDbContext(DbContextOptions<WapDbContext> options)
             : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
