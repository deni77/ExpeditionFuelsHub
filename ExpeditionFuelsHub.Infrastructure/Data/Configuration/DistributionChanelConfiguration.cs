using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Configuration
{
    public class DistributionChanelConfiguration : IEntityTypeConfiguration<DistributionChannel>
    {
        public void Configure(EntityTypeBuilder<DistributionChannel> builder)
        {
            builder.HasData(CreateDistributionChanel());
        }

        private List<DistributionChannel> CreateDistributionChanel()
        {
            List<DistributionChannel> channels = new List<DistributionChannel>()
            {
                new DistributionChannel()
                {
                    Id = 1,
                     Name =     "DistributionChannel_1",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },

                new DistributionChannel()
                {
                    Id = 2,
                     Name =     "DistributionChannel_2",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                 new DistributionChannel()
                {
                    Id = 3,
                     Name =     "DistributionChannel_3",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                  new DistributionChannel()
                {
                    Id = 4,
                     Name =     "DistributionChannel_4",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },

             };

            return channels;
        }
    }
}
