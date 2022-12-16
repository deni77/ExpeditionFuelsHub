using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Services.Admin;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.UnitTests.Services
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IRepository repo;
        private ILogger<VehicleService> logger;
        private IGuard guard;
        private IVehicleService vehicleService;
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
        public async Task TestVehicleAll()
        {
            var loggerMock = new Mock<ILogger<VehicleService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard);

            await repo.AddRangeAsync(new List<Vehicle>()
            {
                new Vehicle
                {
                     Id = 100,
                RegistrationNumber="534543",
                 VehicleRegistrationDocumentNumber="14234243"
                },

            });

            await repo.SaveChangesAsync();
            var vehicleCollection = await vehicleService.All();

            Assert.That(4, Is.EqualTo(vehicleCollection.Count()));
           }

         [Test]
        public async Task TestVehicleAdd()
        {
            var loggerMock = new Mock<ILogger<VehicleService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard);

           var res = vehicleService.Create(new VehicleModel
            {
                 RegistrationNumber = "534543",
                VehicleRegistrationDocumentNumber = "14234243"
            });

            var vehicleCollection = await vehicleService.All();

            Assert.That(4, Is.EqualTo(vehicleCollection.Count()));
           }

          [Test]
        public async Task TestVehicleDetails()
        {
          var loggerMock = new Mock<ILogger<VehicleService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard);

             await repo.AddAsync(new Vehicle()
            {
                Id = 100,
                 RegistrationNumber="11121111",
                 VehicleRegistrationDocumentNumber="232222222"
            });
            await repo.SaveChangesAsync();

            var veh = await vehicleService.VehicleDetailsById(100);

             Assert.That(veh.RegistrationNumber, Is.EqualTo("11121111"));
           }

          [Test]
        public async Task TestVehicleEdits()
        {
          var loggerMock = new Mock<ILogger<VehicleService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard);

             await repo.AddAsync(new Vehicle
            {
                Id = 160,
                RegistrationNumber = "AC7686GV", 
                 VehicleRegistrationDocumentNumber = "768432908" 
            });

            await repo.SaveChangesAsync();

            await vehicleService.Edit(160, new VehicleModel()
            {
                 RegistrationNumber = "CC7686GV", 
                 VehicleRegistrationDocumentNumber = "768432908" 
            });

            var dbVeh = await repo.GetByIdAsync<Vehicle>(160);

             Assert.That(dbVeh.RegistrationNumber, Is.EqualTo("CC7686GV"));
           }

          [Test]
        public async Task TestVehicleExists()
        {
            var res = await vehicleService.Exists("AV9876BH", "ACF4566AS");

            Assert.That(true, Is.EqualTo(res));
           }

           [Test]
        public async Task TestVehicleExistsById()
        {
            var res = await vehicleService.Exists(1);

            Assert.That(true, Is.EqualTo(res));
           }

         [Test]
        public async Task TestVehicleDelete()
        {
             var loggerMock = new Mock<ILogger<VehicleService>>();
            logger = loggerMock.Object;

            repo = new Repository(applicationDbContext);

            vehicleService = new VehicleService(repo, guard );

            await repo.AddAsync(new Vehicle
            {
                Id = 151,
                     VehicleRegistrationDocumentNumber="3456VGBHN",
                      RegistrationNumber="34RTFV54"
            });

            await repo.SaveChangesAsync();

            await vehicleService.Delete(151);

            var dbDelete = await repo.GetByIdAsync<Vehicle>(151);

            Assert.That(dbDelete.IsActive, Is.EqualTo(false));
        }
    }
}

