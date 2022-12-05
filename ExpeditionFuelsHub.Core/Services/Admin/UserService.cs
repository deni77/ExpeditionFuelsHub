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

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<FuelDispenser>() 
                .Select(a => new UserServiceModel() 
                {
                    UserId =a.UserId,
                    Email = a.User.Email,
                   PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] fDispenserIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<IdentityUser>()
                .Where(u => fDispenserIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel() 
                {
                    UserId = u.Id,
                    Email = u.Email,
                    PhoneNumber=u.PhoneNumber
                   }).ToListAsync());

            return result;
        }

       // public async Task<string> UserFullName(string userId)
        //{
        //    var user = await repo.GetByIdAsync<IdentityUser>(userId);

        //    return $"{user?.FirstName} {user?.LastName}".Trim();
        //}
    }
}
