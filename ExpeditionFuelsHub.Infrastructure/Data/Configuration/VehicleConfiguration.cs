using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(CreateVehicle());
        }

        private List<Vehicle> CreateVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Id = 1,
                      RegistrationNumber="AV9876BH",
                       VehicleRegistrationDocumentNumber="ACF4566ASSSS",
                      ModifiedOn=DateTime.Now
                },
                 new Vehicle()
                {
                    Id = 2,
                      RegistrationNumber="BB9876aa",
                       VehicleRegistrationDocumentNumber="ACF4566ASSSSFGR",
                      ModifiedOn=DateTime.Now
                },
          };

            return vehicles;
        }
    }
}
