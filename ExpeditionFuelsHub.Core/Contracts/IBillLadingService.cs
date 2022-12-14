using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Models.BillLading.Service;
using ExpeditionFuelsHub.Views.BillLading.EnumSorting;

namespace ExpeditionFuelsHub.Core.Contracts
{
    public interface IBillLadingService
    {
        Task<IEnumerable<BillsDistributionChanelModel>> AllDistributionChanels();

        Task<IEnumerable<BillsProductModel>> AllProducts();

         Task<IEnumerable<BillsVehicleModel>> AllVehicles();

         Task<IEnumerable<BillsPurposeModel>> AllPurposes();
        Task<IEnumerable<BillLadingServiceViewModel>> GetLastTwoBillLadingAsync();
        // Task<IEnumerable<BillladingServiceViewModel>> AllBillLadingAsync();

          Task<BillLadingQueryModel> All(
            string? purpose = null,
            string? searchTerm = null,
            BillLadingSorting sorting = BillLadingSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<int> Create(AddBillLadingViewModel model, int fDispecherId);

        Task<bool> DistributionChanelExists(int distributionChanelId);

        Task<bool> VehicleExists(int vehicleId);

         Task<bool> PurposeExists(int purposeId);
         Task<bool> ProductExists(int productId);

        Task<IEnumerable<string>> AllPurposesNames();

        // za Mine
         Task<IEnumerable<BillLadingServiceModel>> AllBillLadingsByFDispenserId(int id);

        Task<DetailsBillLadingViewModel> BillLadingDetailsById(int id);

        Task<bool> Exists(int id);

         Task Edit(int billLadingId, AddBillLadingViewModel model);
        Task<bool> HasFDispenserWithId(int billId, string currentUserId);

        Task<int> GetBillLadingByPurposeId(int billId);
        
        Task<int> GetBillLadingDistributionChanelId(int billId);
        Task<int> GetBillLadingProductId(int billId);
        Task<int> GetBillLadingVehicleId(int billId);

        Task Delete(int billLadingId);
       }
}
