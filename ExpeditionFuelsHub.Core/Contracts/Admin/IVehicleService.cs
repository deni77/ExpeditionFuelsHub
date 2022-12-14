using ExpeditionFuelsHub.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Contracts.Admin
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleModel>> All();

        Task<int> Create(VehicleModel model);
    }
}
