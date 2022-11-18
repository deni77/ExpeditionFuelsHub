using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Models.BillLading
{
    public class BillLadingServiceViewModel
    {
         public int Id { get; init; }

         public decimal GrossStandardVolume { get; init; }

         public string Vehicle { get; init; }= null!;

          public string Product { get; init; }= null!;

        public string ImageUrl  { get; init; }= null!;
    }
}
