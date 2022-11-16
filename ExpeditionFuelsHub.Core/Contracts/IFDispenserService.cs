using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Contracts
{
    public interface IFDispenserService
    {
        Task<bool> ExistsById(string userId);

        Task<int> GetfDispecherId(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        
        Task Create(string userId, string phoneNumber);

        Task AddToRoleFDispenser(string userId);
    }
}
