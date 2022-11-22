using ExpeditionFuelsHub.Core.Models.BillLading.Service;
using ExpeditionFuelsHub.Core.Models.FDispenser;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;

namespace ExpeditionFuelsHub.Core.Models.BillLading
{
    public class DetailsBillLadingViewModel :BillLadingServiceModel
    {
       public decimal Mass { get; set; }

        public string CreatedOn { get; set; }   

        public FDispenserServiceModel FDispenser { get; set; }
    }
}
