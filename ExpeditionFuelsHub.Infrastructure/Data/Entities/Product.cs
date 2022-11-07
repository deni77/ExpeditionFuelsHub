using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Entities
{
    public class Product
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }= null!;

       [Required]
        [StringLength(50)]
        public string ProductCode  { get; set; }= null!;

        public bool IsValid { get; set; }

        public DateTime ModifiedOn { get; set; }

        public List<BillLading> BillLadings  { get; set; } = new List<BillLading>();
    }
}
