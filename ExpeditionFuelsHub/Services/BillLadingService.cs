using ExpeditionFuelsHub.Contracts;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Models.BillLading;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionFuelsHub.Services
{
    public class BillLadingService : IBillLadingService
    {

        private readonly ApplicationDbContext context;
        public BillLadingService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<BillladingServiceViewModel>> GetLastTwoBillLadingAsync()
        {
            var entities = await this.context.BillLadings
                 .Include(g => g.Vehicle)
                 .Include(g => g.Product)
                .OrderByDescending(x => x.Id).ToListAsync();


           return entities .Select(x => new BillladingServiceViewModel()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                GrossStandardVolume = x.GrossStandardVolume,
                Product = x.Product.FullName,
                Vehicle = x.Vehicle.RegistrationNumber
            })
                .Take(3);
        }
    }
}
