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
   public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateProducts());
        }

        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                     FullName="А-95Н",
                      ProductCode="552",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                 new Product()
                {
                    Id = 2,
                     FullName="А-95НВ",
                      ProductCode="101",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },

                 new Product()
                {
                    Id = 3,
                     FullName="А-98 ЕКТО",
                      ProductCode="102",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },
                   new Product()
                {
                    Id = 4,
                     FullName="А-98 Н1",
                      ProductCode="105",
                        IsValid=true,
                         ModifiedOn=DateTime.Now
                },
          };

            return products;
        }
    }
}
