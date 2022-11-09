using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpeditionFuelsHub.Models.BillLading
{
    public class BillladingServiceViewModel
    {
         public int Id { get; init; }

         public decimal GrossStandardVolume { get; init; }

         public string Vehicle { get; init; }

          public string Product { get; init; }

        public string ImageUrl  { get; init; }
    }
}
