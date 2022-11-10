using ExpeditionFuelsHub.Core.Models.BillLading;

namespace ExpeditionFuelsHub.Core.Contracts
{
    public interface IBillLadingService
    {
        Task<IEnumerable<BillladingServiceViewModel>> GetLastTwoBillLadingAsync();
    }
}
