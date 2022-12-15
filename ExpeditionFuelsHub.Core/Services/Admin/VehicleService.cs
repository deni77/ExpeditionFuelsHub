using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Models.FDispenser;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Services.Admin
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repo;
        public VehicleService(IRepository _repo)
        {
            repo = _repo;
        }


        public async Task<IEnumerable<VehicleModel>> All()
        {
            return await repo.AllReadonly<Vehicle>()
                .OrderBy(c => c.RegistrationNumber)
                .Select(c => new VehicleModel()
                {
                    Id = c.Id,
                    RegistrationNumber = c.RegistrationNumber,
                    VehicleRegistrationDocumentNumber = c.VehicleRegistrationDocumentNumber
                })
                .ToListAsync();
        }

        public async Task<VehicleModel> VehicleDetailsById(int id)
        {
             return await repo.AllReadonly<Vehicle>()
               .Where(h => h.IsActive)
               .Where(h => h.Id == id)
               .Select(h => new VehicleModel()
               {
                    RegistrationNumber=h.RegistrationNumber,
                    VehicleRegistrationDocumentNumber=h.VehicleRegistrationDocumentNumber
                    })
               .FirstAsync();
        }

        public async Task<int> Create(VehicleModel model)
        {
            var res = await this.Exists(model.RegistrationNumber, model.VehicleRegistrationDocumentNumber);
            if (res==true)
            {
                return 0;
            }

            var vehicle = new Vehicle()
            {
                RegistrationNumber = model.RegistrationNumber,
                VehicleRegistrationDocumentNumber = model.VehicleRegistrationDocumentNumber,

                // IsActive = true,
            };


            await repo.AddAsync(vehicle);
            await repo.SaveChangesAsync();

            return vehicle.Id;
        }

        public async Task Edit(int vehicleId, VehicleModel model)
        {
            var vehicle = await repo.GetByIdAsync<Vehicle>(vehicleId);
           // guard.AgainstNull(bill, "BillLading can not be found !");

            vehicle.RegistrationNumber = model.RegistrationNumber;
            vehicle.VehicleRegistrationDocumentNumber = model.VehicleRegistrationDocumentNumber;

            vehicle.Id = model.Id;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(string registrationNumber, string vehicleRegistrationDocumentNumber)
        {
            var res = await repo.AllReadonly<Vehicle>()
                 .Where(u=>u.VehicleRegistrationDocumentNumber==vehicleRegistrationDocumentNumber 
                            && u.RegistrationNumber==registrationNumber).ToListAsync();
            if (res.Count!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            var res = await repo.AllReadonly<Vehicle>()
                 .Where(u=>u.Id==id).ToListAsync();
            if (res.Count!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

