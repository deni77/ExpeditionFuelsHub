using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Services
{
    public class FdispenserService :IFDispenserService
    {
        private readonly ApplicationDbContext context;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly  UserManager<IdentityUser> userManager;

        public FdispenserService(ApplicationDbContext _context,SignInManager<IdentityUser> _signInManager, 
                                UserManager<IdentityUser> _userManager)
        {
            context = _context;
            signInManager = _signInManager;
            this.userManager = _userManager; 
        }

        public async Task AddToRoleFDispenser(string userId)
        {
            var iuserrole = new IdentityUserRole<string>
            {
                RoleId = "115e174e-5g0e-i46f-86af-458mkifd7210",
                UserId = userId
            };

           await  context.AddAsync(iuserrole);
            context.SaveChanges();

            //sign in and sign out zaradi nowata rolq
            IdentityUser curUser = await userManager.FindByIdAsync(userId);

            await signInManager.SignOutAsync();
            await signInManager.SignInAsync(curUser, false);
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var fdispenser = new FuelDispenser()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await context.AddAsync(fdispenser);
            await context.SaveChangesAsync();

           
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await context.FuelDispensers.AnyAsync(a => a.UserId == userId);
        }

        //public async Task<bool> UserHasRents(string userId)
        //{
        //    return await repo.All<House>()
        //        .AnyAsync(h => h.RenterId == userId);
        //}

          public async Task<int> GetfDispecherId(string userId)
        {
            return (await context.FuelDispensers
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await context.FuelDispensers
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
