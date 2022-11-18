using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Models.BillLading.Service
{
    public class BillLadingQueryModel
    {
      public int TotalBillLadingCount { get; set; }

        public IEnumerable<BillLadingServiceModel> BillLadings { get; set; } = new List<BillLadingServiceModel>();
       }
}
