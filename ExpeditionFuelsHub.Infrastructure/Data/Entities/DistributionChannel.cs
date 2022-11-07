using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Entities
{
    public class DistributionChannel
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }= null!;

        public bool IsValid { get; set; }

        public DateTime ModifiedOn { get; set; }

        public List<BillLading> BillLadings  { get; set; } = new List<BillLading>();
       
    }
}
