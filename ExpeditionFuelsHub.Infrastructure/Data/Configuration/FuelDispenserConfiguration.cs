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
     public class FuelDispenserConfiguration : IEntityTypeConfiguration<FuelDispenser>
    {
        public void Configure(EntityTypeBuilder<FuelDispenser> builder)
        {
            builder.HasData(new FuelDispenser()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
