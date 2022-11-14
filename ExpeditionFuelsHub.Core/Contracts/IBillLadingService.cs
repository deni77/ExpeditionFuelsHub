using ExpeditionFuelsHub.Core.Models.BillLading;

namespace ExpeditionFuelsHub.Core.Contracts
{
    public interface IBillLadingService
    {
        Task<IEnumerable<BillsDistributionChanelModel>> AllDistributionChanels();

        Task<IEnumerable<BillsProductModel>> AllProducts();

         Task<IEnumerable<BillsVehicleModel>> AllVehicles();

         Task<IEnumerable<BillsPurposeModel>> AllPurposes();
        Task<IEnumerable<BillladingServiceViewModel>> GetLastTwoBillLadingAsync();

        Task<int> Create(AddBillLadingViewModel model, int fDispecherId);

        Task<bool> DistributionChanelExists(int distributionChanelId);

        Task<bool> VehicleExists(int vehicleId);

         Task<bool> PurposeExists(int purposeId);
         Task<bool> ProductExists(int productId);
    }
}
