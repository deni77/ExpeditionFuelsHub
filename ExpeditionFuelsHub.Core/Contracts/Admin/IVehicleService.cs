using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Core.Models.BillLading;
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

         Task<bool> Exists(string registrationNumber, string VehicleRegistrationDocumentNumber);

         Task<bool> Exists(int id);

         Task Edit(int vehicleId, VehicleModel model);

        Task<VehicleModel> VehicleDetailsById(int id);

        Task Delete(int vehicleId);
    }
}
