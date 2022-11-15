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
                     FullName="Биодизел",
                      ProductCode=100
                },
                 new Product()
                {
                    Id = 2,
                     FullName="Авт.бензин А-100Н-9%Биоетанол",
                      ProductCode=200
                },

                 new Product()
                {
                    Id = 3,
                     FullName="А-98 ЕКТО",
                      ProductCode=300
                       
                },
                   new Product()
                {
                    Id = 4,
                     FullName="А-98 Н1",
                      ProductCode=400
                },
          };

            return products;
        }
    }
}
