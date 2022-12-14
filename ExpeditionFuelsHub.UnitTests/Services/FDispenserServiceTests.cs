using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Services;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class FDispenserServiceTests
    {
        private IRepository repo;
        private ILogger<FdispenserService> logger;
        protected Mock<UserManager<ApplicationUser>> userManager;
        protected Mock<SignInManager<ApplicationUser>> signInManager;
        private IGuard guard;
        private IFDispenserService fDispService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("BillLadingDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            this.userManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);

             signInManager = new Mock<SignInManager<ApplicationUser>>(
            userManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                null, null, null, null);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }



        [Test]
        public async Task TestCreate()
        {
            var loggerMock = new Mock<ILogger<FdispenserService>>();
            logger = loggerMock.Object;
           

            repo = new Repository(applicationDbContext);

            fDispService = new FdispenserService(repo, signInManager.Object, userManager.Object, logger);

            await repo.AddAsync(
                new FuelDispenser()
                {
                    Id=101,
                    UserId = "1",
                    PhoneNumber = "353453"
                });

             await repo.SaveChangesAsync();


            await fDispService.Create("1","34534");

            var dbfdisp = await repo.GetByIdAsync<FuelDispenser>(102);

            Assert.That(dbfdisp.Id, Is.EqualTo(102));

        }

        [Test]
        public async Task TestExistById()
        {
            var loggerMock = new Mock<ILogger<FdispenserService>>();
            logger = loggerMock.Object;


            repo = new Repository(applicationDbContext);

            fDispService = new FdispenserService(repo, signInManager.Object, userManager.Object, logger);

            await repo.AddAsync(
                new FuelDispenser()
                {
                    Id = 101,
                    UserId = "1",
                    PhoneNumber = "353453"
                });

             var res = await fDispService.ExistsById("102");

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public async Task TestGetFDispById()
        {
            var loggerMock = new Mock<ILogger<FdispenserService>>();
            logger = loggerMock.Object;


            repo = new Repository(applicationDbContext);

            fDispService = new FdispenserService(repo, signInManager.Object, userManager.Object, logger);

            await repo.AddAsync(
                new FuelDispenser()
                {
                    Id = 101,
                    UserId = "1",
                    PhoneNumber = "353453"
                });

            var res = await fDispService.GetfDispecherId("1054541");

            Assert.That(res, Is.EqualTo(0));
        }

        [Test]
        public async Task TestUserWithPhoneNumberExists()
        {
            var loggerMock = new Mock<ILogger<FdispenserService>>();
            logger = loggerMock.Object;


            repo = new Repository(applicationDbContext);

            fDispService = new FdispenserService(repo, signInManager.Object, userManager.Object, logger);

            await repo.AddAsync(
                new FuelDispenser()
                {
                    Id = 453454545,
                    PhoneNumber = "353453"
                }); ;

            
            var res = await fDispService.UserWithPhoneNumberExists("9898344");
            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public async Task TestAddToRoleFDispenser()
        {
            var loggerMock = new Mock<ILogger<FdispenserService>>();
            logger = loggerMock.Object;


            repo = new Repository(applicationDbContext);

            fDispService = new FdispenserService(repo,
                signInManager.Object, userManager.Object, logger);



            await fDispService.AddToRoleFDispenser("1");

            await fDispService.AddToRoleFDispenser("87612856-d498-4529-b453-bgrfd8395082");

            var res = await repo.AllReadonly<IdentityUserRole<string>>()
                .Where(x => x.UserId == "1" && x.RoleId == "115e174e-5g0e-i46f-86af-458mkifd7210").ToListAsync();
            var res1 = await repo.AllReadonly<IdentityUserRole<string>>()
                .Where(x => x.UserId == "87612856-d498-4529-b453-bgrfd8395082" && x.RoleId == "115e174e-5g0e-i46f-86af-458mkifd7210").ToListAsync();

            Assert.That(res1.Count, Is.EqualTo(1));
        }



        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}

