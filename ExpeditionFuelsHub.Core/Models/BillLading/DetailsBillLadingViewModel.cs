using ExpeditionFuelsHub.Core.Models.BillLading.Service;
using ExpeditionFuelsHub.Core.Models.FDispenser;

namespace ExpeditionFuelsHub.Core.Models.BillLading
{
    public class DetailsBillLadingViewModel :BillLadingServiceModel
    {
        public string CreatedOn { get; set; }

        public FDispenserServiceModel FDispenser { get; set; }
    }
}
