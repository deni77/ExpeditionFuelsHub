using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.BillLading;
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
        private BillLadingService billLadingService;
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
        public async Task TestLast3HousesNumbersAndOrders()
        {
           var loggerMock = new Mock<ILogger<BillLadingService>>();
           // loggerMock.Setup(l => l.LogError(""));
            logger= loggerMock.Object;

            IAsyncEnumerable<BillLading> billLadings=new List<BillLading>() 
            {
                new BillLading
                {
                     Id = 1,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98",  ProductCode=3},
                Vehicle = new Vehicle(){  RegistrationNumber="AH7686GV", VehicleRegistrationDocumentNumber="765432908"}
                },
                new BillLading
                {
                     Id = 3,
                ImageUrl = "urlff",
                GrossStandardVolume = 32444.43m,
                Product = new Product(){  FullName="A-98H",  ProductCode=4},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7686GV", VehicleRegistrationDocumentNumber="165432908"}
                },
                 new BillLading
                {
                     Id = 5,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98-EKTO",  ProductCode=5},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7656GV", VehicleRegistrationDocumentNumber="165456908"}
                },
                  new BillLading
                {
                     Id = 2,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98-EKTO",  ProductCode=5},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7656GV", VehicleRegistrationDocumentNumber="165456908"}
                }
                
            } as IAsyncEnumerable<BillLading>;

            var repoMock = new Mock<IRepository>();
            repoMock.Setup(r => r.AllReadonly<BillLading>()).Returns((IQueryable<BillLading>)billLadings);//kakwoto testvame w metoda
            repo = repoMock.Object;

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.SaveChangesAsync();
            var billCollection = await billLadingService.GetLastTwoBillLadingAsync();

            Assert.That(3, Is.EqualTo(billCollection.Count()));
            Assert.That(billCollection.Any(h => h.Id == 1), Is.False);
        }


         [Test]
        public async Task TestLast3HousesInMemory()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            billLadingService = new BillLadingService(repo, guard, logger);

            await repo.AddRangeAsync(new List<BillLading>()
            {
                new BillLading
                {
                     Id = 100,
                ImageUrl = "url",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98",  ProductCode=3},
                Vehicle = new Vehicle(){  RegistrationNumber="AH7686GV", VehicleRegistrationDocumentNumber="765432908"}
                },
                new BillLading
                {
                     Id = 111,
                ImageUrl = "urlff",
                GrossStandardVolume = 32444.43m,
                Product = new Product(){  FullName="A-98H",  ProductCode=4},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7686GV", VehicleRegistrationDocumentNumber="165432908"}
                },
                 new BillLading
                {
                     Id = 122,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98-EKTO",  ProductCode=5},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7656GV", VehicleRegistrationDocumentNumber="165456908"}
                },
                  new BillLading
                {
                     Id = 133,
                ImageUrl = "urdslff",
                GrossStandardVolume = 324.43m,
                Product = new Product(){  FullName="A-98-EKTO",  ProductCode=5},
                Vehicle = new Vehicle(){  RegistrationNumber="AC7656GV", VehicleRegistrationDocumentNumber="165456908"}
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
            var repo = new Repository(applicationDbContext);
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
                })  ;

            var dbBill = await repo.GetByIdAsync<BillLading>(150);

            Assert.That(dbBill.GrossStandardVolume, Is.EqualTo(342.234m));
            Assert.That(dbBill.Mass, Is.EqualTo(2343.3432m));
            Assert.That(dbBill.PurposeId, Is.EqualTo(1));
            Assert.That(dbBill.ProductId, Is.EqualTo(1));
            Assert.That(dbBill.DistributionChannelId, Is.EqualTo(3));
            Assert.That(dbBill.VehicleId, Is.EqualTo(1));
            Assert.That(dbBill.DistributionChannel,Is.EqualTo(null) );
            Assert.That(dbBill.FuelDispenser,Is.EqualTo(null) );
             Assert.That(dbBill.ImageUrl,Is.EqualTo("url") );
           Assert.That(dbBill.IsActive,Is.EqualTo(true) );
          }

         [Test]
        public async Task TestHouseDelete()
        {
            var loggerMock = new Mock<ILogger<BillLadingService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
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

           Assert.That(dbBill.IsActive,Is.EqualTo(false) );
          }

         [TearDown]
        public void TearDown()
        {
           applicationDbContext.Dispose();
        }
    }
}
