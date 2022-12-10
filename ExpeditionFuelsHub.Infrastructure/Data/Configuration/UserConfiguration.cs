using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;

namespace ExpeditionFuelsHub.Infrastructure.Data.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasData(CreateUsers());
           
        }

        private void CreateRoles()
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser()
            {
                Id = "87612856-d498-4529-b453-bgrfd8395082",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };

            admin.PasswordHash =
                 hasher.HashPassword(admin, "admin123");

            users.Add(admin);
            //-----------------------------------------------
            var user = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "fdispenser",
                NormalizedUserName = "FDISPENSER",
                Email = "fdispenser@mail.com",
                NormalizedEmail = "FDISPENSER@MAIL.COM"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "fd123");

            users.Add(user);

            //---------------------------------------------
            user = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "guest123");

            users.Add(user);
             //---------------------------------------------
            return users;
        }
    }
}
