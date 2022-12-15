using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionFuelsHub.Core.Services.Admin
{
    public class UserService :IUserService
    {
         private readonly IRepository repo;
         private readonly IFDispenserService fdispenser;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IRepository _repo, IFDispenserService _fdispenser, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            fdispenser = _fdispenser;
            userManager = _userManager;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<FuelDispenser>() 
                .Where(a=>a.User.IsActive)
                .Select(a => new UserServiceModel() 
                {
                    UserId =a.UserId,
                    Email = a.User.Email,
                   PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] fDispenserIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u => u.IsActive == true && (u.Id != "87612856-d498-4529-b453-bgrfd8395082") &&( u.Id!="dea12856-c198-4129-b3f3-b893d8395082"))
                .Where(u => fDispenserIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).ToListAsync()); ;

            return result;
        }

         public async Task<IEnumerable<UserServiceModel>> AssignRole()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<FuelDispenser>()
                .Select(a => new UserServiceModel()
                {
                    UserId = a.UserId,
                    Email = a.User.Email,
                    PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] fDispenserIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u=>u.IsActive==true)
                .Where(u => fDispenserIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).ToListAsync());

            return result;
        }


       public async Task AssignToRole(string iserid)
        {
            Random rd=new Random();
            int num = rd.Next(000000000, 999999999);

            await fdispenser.Create(iserid, num.ToString());
            await fdispenser.AddToRoleFDispenser(iserid);

        }

        public async Task<bool> Forget(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            user.PhoneNumber = null;
             user.Email = null;
            user.IsActive = false;
            user.NormalizedEmail = null;
            user.NormalizedUserName = null;
            user.PasswordHash = null;
            user.UserName = $"forgottenUser-{DateTime.Now.Ticks}";

            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        // public async Task<string> UserFullName(string userId)
        //{
        //    var user = await repo.GetByIdAsync<IdentityUser>(userId);

        //    return $"{user?.FirstName} {user?.LastName}".Trim();
        //}
    }
}
