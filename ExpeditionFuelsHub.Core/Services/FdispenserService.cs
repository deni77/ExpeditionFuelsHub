using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
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
        public FdispenserService(ApplicationDbContext _context)
        {
            context = _context;
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
