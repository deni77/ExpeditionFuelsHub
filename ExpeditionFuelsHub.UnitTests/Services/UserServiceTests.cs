using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Services.Admin;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
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
    public class UserSevicesTests
    {

        private IRepository repo;
        private ILogger<UserService> logger;
        protected Mock<UserManager<ApplicationUser>> userManager;
        protected Mock<SignInManager<ApplicationUser>> signInManager;
        private IGuard guard;
        private IUserService userService;
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
        public async Task TestAll()
        {
            var loggerMock = new Mock<ILogger<UserService>>();
            logger = loggerMock.Object;

            var FdispenseSErviceMock = new Mock<IFDispenserService>();

            repo = new Repository(applicationDbContext);

            userService = new UserService(repo,FdispenseSErviceMock.Object, userManager.Object);

            var res = userService.All();
            Assert.That(res, Is.Not.Null);

        }

        [Test]
        public async Task TestAssignRole()
        {
            var loggerMock = new Mock<ILogger<UserService>>();
            logger = loggerMock.Object;

            var FdispenseSErviceMock = new Mock<IFDispenserService>();

            repo = new Repository(applicationDbContext);

            userService = new UserService(repo, FdispenseSErviceMock.Object, userManager.Object);

            var res = userService.AssignRole();
            Assert.That(res, Is.Not.Null);

        }

        [Test]
        public async Task TestAssignToRole()
        {
            var loggerMock = new Mock<ILogger<UserService>>();
            logger = loggerMock.Object;

            var FdispenseSErviceMock = new Mock<IFDispenserService>();

            repo = new Repository(applicationDbContext);

            userService = new UserService(repo, FdispenseSErviceMock.Object, userManager.Object);

            await userService.AssignToRole("1");

            var res = await repo.AllReadonly<IdentityUserRole<string>>()
               .Where(x => x.UserId == "1" && x.RoleId == "115e174e-5g0e-i46f-86af-458mkifd7210").ToListAsync();

            Assert.That(res, Is.Not.Null);

        }
        
    }
}

