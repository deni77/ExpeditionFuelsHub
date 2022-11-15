using ExpeditionFuelsHub.Infrastructure.Data.Configuration;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace ExpeditionFuelsHub.Infrastrucure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> //, 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BillLading> BillLadings { get; set; } = null!;

        public DbSet<DistributionChannel> DistributionChannels { get; set; }= null!;
        public DbSet<FuelDispenser> FuelDispensers { get; set; }= null!;
        public DbSet<Product> Products { get; set; }= null!;
        public DbSet<Purpose> Purposes { get; set; }= null!;

        public DbSet<Vehicle> Vehicles { get; set; }= null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<User>().ToTable("AspNetUsers");

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FuelDispenserConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new PurposeConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
              builder.ApplyConfiguration(new DistributionChanelConfiguration());

            builder.ApplyConfiguration(new BillLadingConfiguration());
         

              base.OnModelCreating(builder);
          //  builder.Entity<User>().ToTable("AspNetUsers");
        }

    }
}