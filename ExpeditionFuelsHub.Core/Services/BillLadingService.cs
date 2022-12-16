using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Core.Models.BillLading;
using Microsoft.EntityFrameworkCore;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using static ExpeditionFuelsHub.Core.Models.BillLading.Service.BillLadingQueryModel;
using ExpeditionFuelsHub.Views.BillLading.EnumSorting;
using ExpeditionFuelsHub.Core.Models.BillLading.Service;
using ExpeditionFuelsHub.Core.Models.FDispenser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ExpeditionFuelsHub.Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace ExpeditionFuelsHub.Services
{
    public class BillLadingService : IBillLadingService
    {

        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;
        public BillLadingService(IRepository _repo, IGuard _guard, ILogger<BillLadingService> _logger)
        {
            repo = _repo;
            guard = _guard;
            logger = _logger;
        }

        public async Task<BillLadingQueryModel> All(string? purpose = null, string? searchTerm = null,
            BillLadingSorting sorting = BillLadingSorting.Newest, int currentPage = 1, int billladingPerPage = 1)
        {
            BillLadingQueryModel result = new BillLadingQueryModel();
            var billLadings = repo.AllReadonly<BillLading>().Where(b => b.IsActive);

            if (string.IsNullOrEmpty(purpose) == false)
            {
                billLadings = billLadings
                    .Where(h => h.Purpose.Name == purpose);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                billLadings = billLadings
                    .Where(h => EF.Functions.Like(h.DistributionChannel.Name.ToLower(), searchTerm) ||
                         EF.Functions.Like(h.Product.FullName.ToLower(), searchTerm));
            }

            billLadings = sorting switch
            {
                BillLadingSorting.GrossStandartVolume => billLadings
                    .OrderBy(h => h.GrossStandardVolume),
                _ => billLadings.OrderByDescending(h => h.Id)
            };

            result.BillLadings = await billLadings
                 .Skip((currentPage - 1) * billladingPerPage)
                 .Take(billladingPerPage)
                 .Select(h => new BillLadingServiceModel
                 {
                     Product = h.Product.FullName,
                     Id = h.Id,
                     ImageUrl = h.ImageUrl,
                     DistributionChannel = h.DistributionChannel.Name,
                     Purpose = h.Purpose.Name,
                     Vehicle = h.Vehicle.RegistrationNumber,
                     GrossStandardVolume = h.GrossStandardVolume
                 })
                 .ToListAsync();

            result.TotalBillLadingCount = await billLadings.CountAsync();

            return result;
        }

        //public async Task<IEnumerable<BillladingServiceViewModel>> AllBillLadingAsync()
        //{
        //     var entities = await this.repo.AllReadonly<BillLading>()
        //         .Include(g => g.Vehicle)
        //         .Include(g => g.Product)
        //         .Include(g => g.DistributionChannel)
        //         .Include(g => g.Purpose)
        //        .OrderByDescending(x => x.Id).ToListAsync();

        //    return entities.Select(x => new BillladingServiceViewModel()
        //    {
        //        Id = x.Id,
        //        ImageUrl = x.ImageUrl,
        //          DistributionChannel=x.DistributionChannel.Name,
        //           Purpose=x.Purpose.Name,
        //        GrossStandardVolume = x.GrossStandardVolume,
        //        Product = x.Product.FullName,
        //        Vehicle = x.Vehicle.RegistrationNumber
        //    });
        //}

        public async Task<IEnumerable<BillsDistributionChanelModel>> AllDistributionChanels()
        {
            return await repo.AllReadonly<DistributionChannel>()
                .OrderBy(c => c.Name)
                .Select(c => new BillsDistributionChanelModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BillLadingServiceModel>> AllBillLadingsByFDispenserId(int id)
        {
            return await repo.AllReadonly<BillLading>()
                  .Where(h => h.FuelDispenserId == id && h.IsActive == true)
                .Select(h => new BillLadingServiceModel()
                {
                    Product = h.Product.FullName,
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    DistributionChannel = h.DistributionChannel.Name,
                    Purpose = h.Purpose.Name,
                    Vehicle = h.Vehicle.RegistrationNumber,
                    GrossStandardVolume = h.GrossStandardVolume
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsProductModel>> AllProducts()
        {
            return await repo.AllReadonly<Product>()
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
            return await repo.AllReadonly<Purpose>()
                .OrderBy(c => c.Name)
                .Select(c => new BillsPurposeModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPurposesNames()
        {
            return await repo.AllReadonly<Purpose>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsVehicleModel>> AllVehicles()
        {
            return await repo.AllReadonly<Vehicle>()
                .Where(c=>c.IsActive)
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
                DistributionChannelId = model.DistributionChanelId,
                ProductId = model.ProductId,
                PurposeId = model.PurposeId,
                VehicleId = model.VehicleId,
                FuelDispenserId = fDispecherId,
                IsActive = true,
            };

            await repo.AddAsync(billLading);
            await repo.SaveChangesAsync();

            return billLading.Id;
        }

        public async Task<bool> DistributionChanelExists(int distributionChanelId)
        {
            return await repo.AllReadonly<DistributionChannel>()
                 .AnyAsync(c => c.Id == distributionChanelId);
        }

        public async Task<IEnumerable<BillLadingServiceViewModel>> GetLastTwoBillLadingAsync()
        {
            var entities = await this.repo.AllReadonly<BillLading>()
                .Where(b => b.IsActive)
                 .Include(g => g.Vehicle)
                 .Include(g => g.Product)
                .OrderByDescending(x => x.Id).ToListAsync();


            return entities.Select(x => new BillLadingServiceViewModel()
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
            return await repo.AllReadonly<Product>()
                .AnyAsync(c => c.Id == productId);
        }

        public async Task<bool> PurposeExists(int purposeId)
        {
            return await repo.AllReadonly<Purpose>()
                 .AnyAsync(c => c.Id == purposeId);
        }

        public async Task<bool> VehicleExists(int vehicleId)
        {
            return await repo.AllReadonly<Vehicle>()
               .AnyAsync(c => c.Id == vehicleId);
        }

        public async Task<DetailsBillLadingViewModel> BillLadingDetailsById(int id)
        {
            return await repo.AllReadonly<BillLading>()
               .Where(h => h.IsActive)
               .Where(h => h.Id == id)
               .Select(h => new DetailsBillLadingViewModel()
               {
                   DistributionChannel = h.DistributionChannel.Name,

                   GrossStandardVolume = h.GrossStandardVolume,
                   Purpose = h.Purpose.Name,
                   Vehicle = h.Vehicle.RegistrationNumber,
                   Id = id,
                   ImageUrl = h.ImageUrl,
                   CreatedOn = h.CreatedOn.ToString("dd.MM.yyyy hh:MM:ss"),
                   Mass = h.Mass,
                   Product = h.Product.FullName,

                   FDispenser = new FDispenserServiceModel()
                   {
                       Email = h.FuelDispenser.User.Email,
                       PhoneNumber = h.FuelDispenser.PhoneNumber
                   }

               })
               .FirstAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<BillLading>()
                .AnyAsync(h => h.Id == id && h.IsActive);
        }

        public async Task Edit(int billLadingId, AddBillLadingViewModel model)
        {
            var bill = await repo.GetByIdAsync<BillLading>(billLadingId);
            guard.AgainstNull(bill, "BillLading can not be found !");

            bill.GrossStandardVolume = model.GrossStandartVolume;
            bill.Mass = model.Mass;
            bill.PurposeId = model.PurposeId;
            bill.ProductId = model.ProductId;
            //bill.CreatedOn = DateTime.ParseExact(model.CreatedOn, "dd-MM-yyyy HH:mm:ss.fffffff", System.Globalization.CultureInfo.InvariantCulture);
            bill.CreatedOn = model.CreatedOn;
            bill.DistributionChannelId = model.DistributionChanelId;

            bill.VehicleId = model.VehicleId;

            await repo.SaveChangesAsync();


        }

        public async Task<bool> HasFDispenserWithId(int billId, string currentUserId)
        {
            bool result = false;
            var bill = await repo.AllReadonly<BillLading>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == billId)
                .Include(h => h.FuelDispenser)
                .FirstOrDefaultAsync();

            guard.AgainstNull(bill, "BillLading can not be found !");

            if (bill?.FuelDispenser != null && bill.FuelDispenser.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> GetBillLadingByPurposeId(int billId) // isActive trqbva li?
        {
            return (await repo.GetByIdAsync<BillLading>(billId)).PurposeId;
        }
        public async Task<int> GetBillLadingDistributionChanelId(int billId)
        {
            return (await repo.GetByIdAsync<BillLading>(billId)).DistributionChannelId;
        }
        public async Task<int> GetBillLadingProductId(int billId)
        {
            return (await repo.GetByIdAsync<BillLading>(billId)).ProductId;
        }
        public async Task<int> GetBillLadingVehicleId(int billId)
        {
            return (await repo.GetByIdAsync<BillLading>(billId)).VehicleId;
        }

        public async Task Delete(int billLadingId)
        {
            var bill = await repo.GetByIdAsync<BillLading>(billLadingId);
            guard.AgainstNull(bill, "BillLading can not be found !");

            bill.IsActive = false;


            await repo.SaveChangesAsync();
        }
    }
}
