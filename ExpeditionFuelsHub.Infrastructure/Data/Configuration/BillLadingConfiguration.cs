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
                          FuelDispenserId=1,
                            DistributionChannelId=1,
                             ProductId=1,
                              PurposeId=1,
                               VehicleId=1,
                                ImageUrl="https://i.trade-cloud.com.cn/upload/6653/image/20211230/2_182318.jpg"
                },
                new BillLading()
                {
                    Id = 2,
                     Mass=34453423.879M,
                      GrossStandardVolume=9345768.876M,
                       CreatedOn=DateTime.Now,
                        FuelDispenserId=1,
                        DistributionChannelId=2,
                        ProductId=2,
                        PurposeId=2,
                        VehicleId=1,
                        ImageUrl="https://autoline.bg/img/s/vlekach-MAN-TGS-18-400---1598979707951979529_big--20090119595756984600.jpg"
                },
                new BillLading()
                {
                    Id = 3,
                     Mass=344423.879M,
                      GrossStandardVolume=93768.876M,
                       CreatedOn=DateTime.Now,
                        FuelDispenserId=1,
                        DistributionChannelId=3,
                        ProductId=3,
                        PurposeId=3,
                        VehicleId=3,
                        ImageUrl="https://bg.csc-trucks.com/uploads/202221798/foton-10-000-liters-oil-tank-truck23496909900.jpg"
                 },
               
                 };

            return billLadings;
        }
    }
}
