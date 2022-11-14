using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpeditionFuelsHub.Core.Models.BillLading
{
    public class BillladingServiceViewModel
    {
         public int Id { get; init; }

         public decimal GrossStandardVolume { get; init; }

         public string Vehicle { get; init; }= null!;

          public string Product { get; init; }= null!;

        public string ImageUrl  { get; init; }= null!;
    }
}
