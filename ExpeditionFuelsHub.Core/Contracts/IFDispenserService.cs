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

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        
       // Task<bool> UserHasRents(string userId);

        Task Create(string userId, string phoneNumber);
    }
}
