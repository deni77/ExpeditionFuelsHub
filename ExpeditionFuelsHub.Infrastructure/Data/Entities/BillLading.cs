using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Entities
{
    public class BillLading
    {
         [Key]
        public int Id { get; set; }

        public DateTime CreatedOn  { get; set; }

        [Required]
          public string ImageUrl  { get; set; }= null!;

        [Required]
         [Precision(18,3)]
        public decimal GrossStandardVolume { get; set; }

         [Required]
         [Precision(18,3)]
        public decimal Mass  { get; set; }

        [Required]
        public int ProductId { get; set; }

         [ForeignKey(nameof(ProductId))]
        public Product Product { get; init; }= null!;

        [Required]
         public int PurposeId { get; set; }

         [ForeignKey(nameof(PurposeId))]
        public Purpose Purpose { get; init; }= null!;

        [Required]
         public int DistributionChannelId { get; set; }

         [ForeignKey(nameof(DistributionChannelId))]
        public DistributionChannel DistributionChannel { get; set; }= null!;

        [Required]
         public int VehicleId { get; set; }

         [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; init; }= null!;

       
        [Required]
         public int FuelDispenserId { get; set; }

         [ForeignKey(nameof(FuelDispenserId))]
        public FuelDispenser FuelDispenser { get; init; }= null!;

            
    }
}
