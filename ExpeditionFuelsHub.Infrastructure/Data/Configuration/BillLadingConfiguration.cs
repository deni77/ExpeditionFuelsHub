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
                             ProductId=1,
                              PurposeId=1,
                               VehicleId=1,
                                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGHWB3llPsds5z8yK2Ao6aOe0eN2-mATIz0A&usqp=CAU",
                                IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                new BillLading()
                {
                    Id = 2,
                     Mass=34453423.879M,
                      GrossStandardVolume=9345768.876M,
                       CreatedOn=DateTime.Now,
                        WriterUserId="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                           FuelDispenserId=1,
                            DistributionChannelId=2,
                             ProductId=2,
                              PurposeId=2,
                               VehicleId=2,
                                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSwnnNTq0ReeB8PmhEqEUHusI9fQPqahEybcQ&usqp=CAU",
                                IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                new BillLading()
                {
                    Id = 3,
                     Mass=344423.879M,
                      GrossStandardVolume=93768.876M,
                       CreatedOn=DateTime.Now,
                        WriterUserId="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                           FuelDispenserId=1,
                            DistributionChannelId=3,
                             ProductId=3,
                              PurposeId=3,
                               VehicleId=3,
                                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyEOLtQgfY1cO9HOE9ykg0r1rA-GGM2Fd0yQ&usqp=CAU",
                                IsValid=true,
                         ModifiedOn=DateTime.Now
                },
               
                 };

            return billLadings;
        }
    }
}
