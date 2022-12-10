using ExpeditionFuelsHub.Infrastructure.Data.Configuration;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExpeditionFuelsHub.Infrastrucure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string> //, 
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

            //create roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "2787b74e-3c0v-466f-m8af-654d56fd9010", Name = "User", NormalizedName = "User" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "115e174e-5g0e-i46f-86af-458mkifd7210", Name = "Fdispenser", NormalizedName = "FDISPENSER" });

            //Seeding the relation between our user and role to AspNetUserRoles table
            //admin - rolq admin
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                UserId = "87612856-d498-4529-b453-bgrfd8395082"
            }
        );

             //guest - rolq user
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2787b74e-3c0v-466f-m8af-654d56fd9010", 
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            }
        );

            //fdispenser - rolq fdispenser
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "115e174e-5g0e-i46f-86af-458mkifd7210", 
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            }
        );

        }

    }
}