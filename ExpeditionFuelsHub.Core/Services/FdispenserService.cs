using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Services
{
    public class FdispenserService :IFDispenserService
    {
      private readonly IRepository repo;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly  UserManager<ApplicationUser> userManager;
         private readonly ILogger logger;

        public FdispenserService(IRepository _repo,SignInManager<ApplicationUser> _signInManager, 
                                UserManager<ApplicationUser> _userManager, ILogger<FdispenserService> _logger)
        {
            repo = _repo;
            signInManager = _signInManager;
            this.userManager = _userManager;
            logger = _logger;
        }

        public async Task AddToRoleFDispenser(string userId)
        {
            var iuserrole = new IdentityUserRole<string>
            {
                RoleId = "115e174e-5g0e-i46f-86af-458mkifd7210",
                UserId = userId
            };

             try
            {
                await repo.AddAsync(iuserrole);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddToRoleFDispenser), ex);
                throw new ApplicationException("Database failed to AddToRoleFDispenser", ex);
            }
                        
            //sign in and sign out zaradi nowata rolq
            ApplicationUser curUser = await userManager.FindByIdAsync(userId);

            if (userId=="87612856-d498-4529-b453-bgrfd8395082")
            {
                await signInManager.SignOutAsync();
            await signInManager.SignInAsync(curUser, false);
            }
            
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var fdispenser = new FuelDispenser()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

          try
            {
                await repo.AddAsync(fdispenser);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
           
        }

        public async Task<bool> ExistsById(string userId)
        {
           // return await context.FuelDispensers.AnyAsync(a => a.UserId == userId);
         return  await repo.AllReadonly<FuelDispenser>().AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetfDispecherId(string userId)
        {
            return (await repo.AllReadonly<FuelDispenser>().FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.AllReadonly<FuelDispenser>().AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
