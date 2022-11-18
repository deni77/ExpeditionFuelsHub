using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpeditionFuelsHub.Core.Models.BillLading.Service
{
    public class BillLadingServiceModel
    {
        public int Id { get; init; }

         public decimal GrossStandardVolume { get; init; }

         public string Vehicle { get; init; }= null!;

         public string DistributionChannel { get; init; }= null!;

        public string Purpose { get; init; }= null!;


          public string Product { get; init; }= null!;

          [Display(Name = "Image URL")]
        public string ImageUrl  { get; init; }= null!;
    }
}
