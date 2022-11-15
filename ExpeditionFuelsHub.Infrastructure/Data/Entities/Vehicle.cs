using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Entities
{
    public class Vehicle
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        public string VehicleRegistrationDocumentNumber { get; set; } = null!;

        [Required]
        [StringLength(8)]
        public string RegistrationNumber  { get; set; }= null!;

        public List<BillLading> BillLadings  { get; set; } = new List<BillLading>();
   
    }
}
