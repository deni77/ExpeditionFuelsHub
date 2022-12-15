using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Core.Services.Admin;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
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

            vehicleService = new VehicleService(repo);

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

            vehicleService = new VehicleService(repo);

           var res = vehicleService.Create(new VehicleModel
            {
                 RegistrationNumber = "534543",
                VehicleRegistrationDocumentNumber = "14234243"
            });

            var vehicleCollection = await vehicleService.All();

            Assert.That(4, Is.EqualTo(vehicleCollection.Count()));
           }

          [Test]
        public async Task TestVehicleExists()
        {
            var res = await vehicleService.Exists("AV9876BH", "ACF4566AS");

            Assert.That(true, Is.EqualTo(res));
           }
    }
}

