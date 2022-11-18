using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Core.Models.BillLading;
using Microsoft.EntityFrameworkCore;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using static ExpeditionFuelsHub.Core.Models.BillLading.Service.BillLadingQueryModel;
using ExpeditionFuelsHub.Views.BillLading.EnumSorting;
using ExpeditionFuelsHub.Core.Models.BillLading.Service;

namespace ExpeditionFuelsHub.Services
{
    public class BillLadingService : IBillLadingService
    {

        private readonly IRepository repo;
        public BillLadingService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<BillLadingQueryModel> All(string? purpose = null, string? searchTerm = null,
            Sorting sorting = Sorting.Newest, int currentPage = 1, int billladingPerPage = 1)
        {
            BillLadingQueryModel result = new BillLadingQueryModel();
            var billLadings = repo.AllReadonly<BillLading>();

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
                        EF.Functions.Like(h.Vehicle.RegistrationNumber.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Product.FullName.ToLower(), searchTerm));
            }

            //switch (sorting)
            //{
            //    case HouseSorting.Price:
            //        houses = houses
            //        .OrderBy(h => h.PricePerMonth);
            //        break;
            //    //    default:
            //        houses = houses.OrderByDescending(h => h.Id);
            //        break;
            //}

            billLadings = sorting switch
            {
                Sorting.GrossStandartVolume => billLadings
                    .OrderBy(h => h.GrossStandardVolume),
                Sorting.Newest => billLadings
                    .OrderBy(h => h.CreatedOn),
                _ => billLadings.OrderByDescending(h => h.Id)
            };

           result.BillLadings = await billLadings
                .Skip((currentPage - 1) * billladingPerPage)
                .Take(billladingPerPage)
                .Select(h => new BillLadingServiceModel
                {
                    Product=h.Product.FullName,
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    //IsRented = h.RenterId != null,
                    DistributionChannel=h.DistributionChannel.Name,
                     Purpose=h.Purpose.Name,
                      Vehicle=h.Vehicle.RegistrationNumber,
                       GrossStandardVolume=h.GrossStandardVolume
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

        
    }
}
