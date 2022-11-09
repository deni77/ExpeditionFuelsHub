using ExpeditionFuelsHub.Models.BillLading;

namespace ExpeditionFuelsHub.Contracts
{
    public interface IBillLadingService
    {
        Task<IEnumerable<BillladingServiceViewModel>> GetLastTwoBillLadingAsync();
    }
}
