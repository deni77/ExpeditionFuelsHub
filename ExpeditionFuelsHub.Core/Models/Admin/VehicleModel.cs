using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Models.Admin
{
   public class VehicleModel
    {
        public int Id { get; set; }

       [RegularExpression(@"^[0-9A-Z]{9,9}$", ErrorMessage = "VehicleRegistrationDocumentNumber must be exactly 9 symbols (digits or chars upper case). ")] 
        public string VehicleRegistrationDocumentNumber { get; set; } = null!;

         [RegularExpression(@"^[0-9A-Z]{8,8}$", ErrorMessage = "RegistrationNumber must be exactly 8 symbols (digits or chars upper case). ")]
     public string RegistrationNumber { get; set; } = null!;
    }
}
