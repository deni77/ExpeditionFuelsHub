using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Models.Admin
{
   public class VehicleModel
    {
        public int Id { get; set; }
        public string VehicleRegistrationDocumentNumber { get; set; } = null!;

     public string RegistrationNumber { get; set; } = null!;
    }
}
