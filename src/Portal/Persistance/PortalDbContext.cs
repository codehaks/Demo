using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Identity;

namespace Portal.Persistance
{
    public class PortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
                : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }


        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new FoodConfig());
            base.OnModelCreating(builder);
        }
    }
}
