using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Services;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Services;
using Hangfire.MemoryStorage.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guard = ExpeditionFuelsHub.Core.Exceptions.Guard;

namespace ExpeditionFuelsHub.UnitTests.Services
{
    [TestFixture]
    public class BillLadingServiceTests
    {
       private IRepository repo;
        private ILogger<BillLadingService> logger;
        private IGuard guard;
        private IBillLadingService billLadingService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("BillLadingDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestLast3HousesInMemory()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddRangeAsync(new List<BillLading>()
            {
                new BillLading
                {
                     Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                  DistributionChannelId=2,
                   FuelDispenserId=1,
                    PurposeId=2,
                      Mass=899.33m
                },
                new BillLading
                {
                     Id = 111,
                ImageUrl = "urlff",
                GrossStandardVolume = 32444.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                  DistributionChannelId=2,
                   FuelDispenserId=1,
                    PurposeId=2,
                    Mass=899.33m
                },
                 new BillLading
                {
                     Id = 122,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                  DistributionChannelId=2,

                   FuelDispenserId=1,
                    PurposeId=2,
                     Mass=899.33m,

                },
                  new BillLading
                {
                     Id = 133,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                  DistributionChannelId=2,
                   FuelDispenserId=1,
                    PurposeId=2,

                     Mass=899.33m
                }
            });

            await repo.SaveChangesAsync();
            var hoseCollection = await billLadingService.GetLastTwoBillLadingAsync();

            Assert.That(3, Is.EqualTo(hoseCollection.Count()));
            Assert.That(hoseCollection.Any(h => h.Id == 100), Is.False);
        }

        [Test]
        public async Task TestHouseEdit()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);
            await repo.AddAsync(new BillLading
            {
                Id = 150,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                Product = new Product() { FullName = "A-98", ProductCode = 3 },
                Vehicle = new Vehicle() { RegistrationNumber = "AH7686GV", VehicleRegistrationDocumentNumber = "765432908" }
            });

            await repo.SaveChangesAsync();

            await billLadingService.Edit(150, new AddBillLadingViewModel()
            {
                GrossStandartVolume = 342.234m,
                Mass = 2343.3432m,
                PurposeId = 1,
                ProductId = 1,
                CreatedOn = DateTime.Now,
                DistributionChanelId = 3,
                ImageUrl = "https://webnews.bg/uploads/images/15/8615/298615/768x432.jpg?_=1497260116",
                VehicleId = 1,
            });

            var dbBill = await repo.GetByIdAsync<BillLading>(150);

            Assert.That(dbBill.GrossStandardVolume, Is.EqualTo(342.234m));
            Assert.That(dbBill.Mass, Is.EqualTo(2343.3432m));
            Assert.That(dbBill.PurposeId, Is.EqualTo(1));
            Assert.That(dbBill.ProductId, Is.EqualTo(1));
            Assert.That(dbBill.DistributionChannelId, Is.EqualTo(3));
            Assert.That(dbBill.VehicleId, Is.EqualTo(1));
            Assert.That(dbBill.DistributionChannel, Is.EqualTo(null));
            Assert.That(dbBill.FuelDispenser, Is.EqualTo(null));
            Assert.That(dbBill.ImageUrl, Is.EqualTo("url"));
            Assert.That(dbBill.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task TestHouseDelete()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading
            {
                Id = 151,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                IsActive = true,
                Product = new Product() { FullName = "A-98", ProductCode = 3 },
                Vehicle = new Vehicle() { RegistrationNumber = "AH7686GV", VehicleRegistrationDocumentNumber = "765432908" }
            });

            await repo.SaveChangesAsync();

            await billLadingService.Delete(151);

            var dbBill = await repo.GetByIdAsync<BillLading>(151);

            Assert.That(dbBill.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task TestProductPurposeVehicleChanelExists()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new Product
            {
                Id = 151,
                FullName = "A"
            });

            await repo.AddAsync(new Purpose
            {
                Id = 151,
                Code = 2423,
                Name = "asds"
            });

            await repo.AddAsync(new Vehicle
            {
                Id = 151,
                RegistrationNumber = "sds",
                VehicleRegistrationDocumentNumber = "asds"
            });

            await repo.AddAsync(new DistributionChannel
            {
                Id = 151,
                Name = ""
            });
            await repo.SaveChangesAsync();

            var result = await billLadingService.ProductExists(151);
            Assert.That(result, Is.EqualTo(true));

            var result1 = await billLadingService.VehicleExists(151);
            Assert.That(result1, Is.EqualTo(true));

            var result2 = await billLadingService.DistributionChanelExists(151);
            Assert.That(result2, Is.EqualTo(true));

            var result3 = await billLadingService.PurposeExists(151);
            Assert.That(result3, Is.EqualTo(true));
        }

        [Test]
        public async Task TestAllProduct()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product(){ Id = 100, FullName = "A" },

            });

            await repo.SaveChangesAsync();

            var allProductsNames = await billLadingService.AllProducts();

            Assert.That(allProductsNames.Count(), Is.EqualTo(5));
        }
        [Test]
        public async Task TestAllChanel()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddRangeAsync(new List<DistributionChannel>()
            {
                new DistributionChannel(){ Id = 100, Name = "A" },

            });

            await repo.SaveChangesAsync();

            var allDistrNames = await billLadingService.AllDistributionChanels();

            Assert.That(allDistrNames.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task TestAllVehicle()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);
            await repo.AddRangeAsync(new List<Vehicle>()
            {
                new Vehicle(){ Id = 100,  RegistrationNumber="2342", VehicleRegistrationDocumentNumber="4324" },

            });

            await repo.SaveChangesAsync();

            var allVNames = await billLadingService.AllVehicles();

            Assert.That(allVNames.Count(), Is.EqualTo(4));
        }
        [Test]
        public async Task TestAllPurpose()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddRangeAsync(new List<Purpose>()
            {
                new Purpose(){ Id = 100,   Code=3545, Name="" }
            });

            await repo.SaveChangesAsync();

            var allPNames = await billLadingService.AllPurposesNames();
            var allPNames1 = await billLadingService.AllPurposes();

            Assert.That(allPNames.Count(), Is.EqualTo(5));
            Assert.That(allPNames1.Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task TestCreateIfWorkProperly()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();

            await billLadingService.Create(new AddBillLadingViewModel()
            {
                // Id = 105,
                ImageUrl = "url",
                GrossStandartVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChanelId = 2,
                PurposeId = 2,
                Mass = 899.33m
            }, 1);


            var dbBill = await repo.GetByIdAsync<BillLading>(101);

            Assert.That(dbBill.Id, Is.EqualTo(101));
        }

        [Test]
        public async Task TestHasFdispWithId()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var dbBill = await repo.GetByIdAsync<BillLading>(1);

            var dbFuel = await repo.GetByIdAsync<FuelDispenser>(1);
            await billLadingService.HasFDispenserWithId(1, dbFuel.Id.ToString());

            Assert.That(dbBill.Id, Is.EqualTo(dbFuel.Id));

        }


        [Test]
        public async Task TestHouseDeleteWithException()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);


            await repo.SaveChangesAsync();

            Assert.That(
                async () => await this.billLadingService.Delete(1000),
                Throws.Exception.TypeOf<BillLadingException>());
        }

        [Test]
        public async Task TestGetBillPurposeId_IfWorksProperly()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var dbBill = await repo.GetByIdAsync<BillLading>(100);
            var billPurpose = await billLadingService.GetBillLadingByPurposeId(100);


            Assert.That(dbBill.PurposeId, Is.EqualTo(billPurpose));
        }

        [Test]
        public async Task TestGetBillDistId_IfWorksProperly()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var dbBill = await repo.GetByIdAsync<BillLading>(100);
            var billdis = await billLadingService.GetBillLadingDistributionChanelId(100);
            Assert.That(dbBill.DistributionChannelId, Is.EqualTo(billdis));
        }

        [Test]
        public async Task TestGetBillProdustId_IfWorksProperly()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);
            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var dbBill = await repo.GetByIdAsync<BillLading>(100);
            var billprod = await billLadingService.GetBillLadingProductId(100);
            Assert.That(dbBill.ProductId, Is.EqualTo(billprod));
        }

        [Test]
        public async Task TestGetBillVehicleId_IfWorksProperly()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var dbBill = await repo.GetByIdAsync<BillLading>(100);
            var billvehicle = await billLadingService.GetBillLadingVehicleId(100);
            Assert.That(dbBill.VehicleId, Is.EqualTo(billvehicle));
        }


        [Test]
        public async Task TestExistsWorksProperly()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            // var dbBill = await repo.GetByIdAsync<BillLading>(100);
            bool billexist = await billLadingService.Exists(100);
            Assert.That(billexist, Is.EqualTo(true));
        }


        [Test]
        public async Task AllBillLadingsByFDispenserId()
        {
             var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();

            await billLadingService.AllBillLadingsByFDispenserId(1);
            var dbCar = await repo.GetByIdAsync<BillLading>(1);
            var dbFdisp = await repo.GetByIdAsync<FuelDispenser>(1);

            Assert.That(dbCar.FuelDispenserId, Is.EqualTo(1));
            Assert.That(dbCar.Equals(dbFdisp), Is.False);
        }

        [Test]
        public async Task BillLadingDetailsById()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);
            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();

            var bill = await billLadingService.BillLadingDetailsById(100);

            Assert.That(bill.Id, Is.EqualTo(100));
        }

        [Test]
        public async Task All()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenserId = 1,
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();

            var bills = await billLadingService.All("sad", "sdf", Views.BillLading.EnumSorting.BillLadingSorting.Newest);

            Assert.That(bills.TotalBillLadingCount, Is.EqualTo(0));
        }


        [Test]
        public async Task TestFuelDispenserisSameAsUserIdProperly()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddAsync(new BillLading()
            {
                Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                ProductId = 1,
                VehicleId = 2,
                CreatedOn = DateTime.Now,
                DistributionChannelId = 2,
                FuelDispenser = new FuelDispenser() { UserId = "2", PhoneNumber = "3453" },
                PurposeId = 2,
                Mass = 899.33m
            });

            await repo.SaveChangesAsync();
            var bills = await billLadingService.HasFDispenserWithId(100, "2");
            Assert.That(bills, Is.EqualTo(true));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
        
    }
}
