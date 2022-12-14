using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Models.Admin;
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
            repo=_repo;
        }


        public async Task<IEnumerable<VehicleModel>> All()
        {
            return await repo.AllReadonly<Vehicle>()
                .OrderBy(c => c.RegistrationNumber)
                .Select(c => new VehicleModel()
                {
                    Id = c.Id,
                     RegistrationNumber = c.RegistrationNumber,
                    VehicleRegistrationDocumentNumber = c.RegistrationNumber
                })
                .ToListAsync();
        }
        public async Task<int> Create(VehicleModel model)
        {
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
        }
    }

