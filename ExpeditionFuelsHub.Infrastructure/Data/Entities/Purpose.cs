using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Infrastructure.Data.Entities
{
    public class Purpose
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }= null!;

       [Required]
        [Range(typeof(byte),"0", "20")]
        public byte Code   { get; set; }
        public DateTime ModifiedOn { get; set; }

        public List<BillLading> BillLadings  { get; set; } = new List<BillLading>();
    }
}
