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
                     Name = "Отложен акциз - до данъчен склад в страната",
                      Code=11,
                      },

                new Purpose()
                {
                    Id = 2,
                     Name = "Съдържащи биоетанол",
                      Code=710,
               },
                new Purpose()
                {
                    Id = 3,
                     Name = "Съдържащи биодизел",
                      Code=700,
               },
                new Purpose()
                {
                    Id = 4,
                     Name = "Крайни потребители",
                      Code=400,
                      },
             };

            return places;
        }
    }
}
