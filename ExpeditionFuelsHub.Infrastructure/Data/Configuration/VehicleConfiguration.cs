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
                       VehicleRegistrationDocumentNumber="ACF4566AS",
                      },
                 new Vehicle()
                {
                    Id = 2,
                      RegistrationNumber="BB9876АА",
                       VehicleRegistrationDocumentNumber="GFR768987",
                      },
                  new Vehicle()
                {
                    Id = 3,
                      RegistrationNumber="AB4576АC",
                       VehicleRegistrationDocumentNumber="DFR400987",
                      },
          };

            return vehicles;
        }
    }
}
