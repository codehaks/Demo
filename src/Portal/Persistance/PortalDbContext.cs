using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Identity;

namespace Portal.Persistance
{
    public class PortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
                : base(options)
        {
        }

       

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
