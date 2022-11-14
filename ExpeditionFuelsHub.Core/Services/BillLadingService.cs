using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Core.Models.BillLading;
using Microsoft.EntityFrameworkCore;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;

namespace ExpeditionFuelsHub.Services
{
    public class BillLadingService : IBillLadingService
    {

        private readonly ApplicationDbContext context;
        public BillLadingService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<BillsDistributionChanelModel>> AllDistributionChanels()
        {
            return await context.DistributionChannels
                .OrderBy(c => c.Name)
                .Select(c => new BillsDistributionChanelModel() 
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsProductModel>> AllProducts()
        {
            return await context.Products
                .OrderBy(c => c.FullName)
                .Select(c => new BillsProductModel() 
                {
                    Id = c.Id,
                    FullName = c.FullName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsPurposeModel>> AllPurposes()
        {
            return await context.Purposes
                .OrderBy(c => c.Name)
                .Select(c => new BillsPurposeModel() 
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsVehicleModel>> AllVehicles()
        {
            return await context.Vehicles
                .OrderBy(c => c.RegistrationNumber)
                .Select(c => new BillsVehicleModel() 
                {
                    Id = c.Id,
                    VehicleRegistrationDocumentNumber = c.RegistrationNumber
                })
                .ToListAsync();
        }

        public async Task<int> Create(AddBillLadingViewModel model, int fDispecherId)
        {
            var billLading = new BillLading()
            {
                ImageUrl = model.ImageUrl,
                CreatedOn = model.CreatedOn,
                Mass = model.Mass,
                GrossStandardVolume = model.GrossStandartVolume,
                  DistributionChannelId=model.DistributionChanelId,
                   ProductId=model.ProductId,
                    PurposeId=model.PurposeId,
                     VehicleId=model.VehicleId,
                FuelDispenserId = fDispecherId
            };

            await context.BillLadings.AddAsync(billLading);
            await context.SaveChangesAsync();

            return billLading.Id;
        }

        public async Task<bool> DistributionChanelExists(int distributionChanelId)
        {
           return await context.DistributionChannels
                .AnyAsync(c => c.Id == distributionChanelId);
        }

        public async Task<IEnumerable<BillladingServiceViewModel>> GetLastTwoBillLadingAsync()
        {
            var entities = await this.context.BillLadings
                 .Include(g => g.Vehicle)
                 .Include(g => g.Product)
                .OrderByDescending(x => x.Id).ToListAsync();


           return entities.Select(x => new BillladingServiceViewModel()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                GrossStandardVolume = x.GrossStandardVolume,
                Product = x.Product.FullName,
                Vehicle = x.Vehicle.RegistrationNumber
            })
                .Take(3);
        }

        public async Task<bool> ProductExists(int productId)
        {
            return await context.Products
                .AnyAsync(c => c.Id == productId);
        }

        public async Task<bool> PurposeExists(int purposeId)
        {
           return await context.Purposes
                .AnyAsync(c => c.Id == purposeId);
        }

        public async Task<bool> VehicleExists(int vehicleId)
        {
             return await context.Vehicles
                .AnyAsync(c => c.Id == vehicleId);
        }
    }
}
