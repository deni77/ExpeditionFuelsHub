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
        [StringLength(60)]
        public string FullName { get; set; }= null!;

       [Required]
       public int ProductCode  { get; set; }

        public List<BillLading> BillLadings  { get; set; } = new List<BillLading>();
    }
}
