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
    public class PurposeConfiguration : IEntityTypeConfiguration<Purpose>
    {
        public void Configure(EntityTypeBuilder<Purpose> builder)
        {
            builder.HasData(CreatePurpose());
        }

        private List<Purpose> CreatePurpose()
        {
            List<Purpose> places = new List<Purpose>()
            {
                new Purpose()
                {
                    Id = 1,
                     Name = "ForCountry",
                      Code=65,
                      ModifiedOn=DateTime.Now
                },

                new Purpose()
                {
                    Id = 2,
                     Name = "ForCountry_1",
                      Code=66,
                      ModifiedOn=DateTime.Now
                },
                new Purpose()
                {
                    Id = 3,
                     Name = "ForCountry_3",
                      Code=64,
                      ModifiedOn=DateTime.Now
                },
                new Purpose()
                {
                    Id = 4,
                     Name = "ForCountry_4",
                      Code=67,
                      ModifiedOn=DateTime.Now
                },

             };

            return places;
        }
    }
}
