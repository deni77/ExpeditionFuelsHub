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

       [RegularExpression(@"^[0-9]{9,9}$", ErrorMessage = "VehicleRegistrationDocumentNumber must be exactly 9 symbols. ")] 
        public string VehicleRegistrationDocumentNumber { get; set; } = null!;

         [RegularExpression(@"^[0-9]{8,8}$", ErrorMessage = "VehicleRegistrationDocumentNumber must be exactly 8 symbols. ")]
     public string RegistrationNumber { get; set; } = null!;
    }
}
