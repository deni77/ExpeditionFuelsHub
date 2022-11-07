﻿using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Configuration
{
  public class BillLadingConfiguration :  IEntityTypeConfiguration<BillLading>
    {
        public void Configure(EntityTypeBuilder<BillLading> builder)
        {
            builder.HasData(CreateBillLading());
        }

        private List<BillLading> CreateBillLading()
        {
            List<BillLading> billLadings = new List<BillLading>()
            {
                new BillLading()
                {
                    Id = 1,
                     Mass=3423.879M,
                      GrossStandardVolume=9768.876M,
                       CreatedOn=DateTime.Now,
                        WriterUserId="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                           FuelDispenserId=1,
                            DistributionChannelId=1,
                             ProductId=2,
                              PurposeId=2,
                               VehicleId=2,
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },

               
                 };

            return billLadings;
        }
    }
}
