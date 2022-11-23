using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Exceptions;
using ExpeditionFuelsHub.Core.Services;
using ExpeditionFuelsHub.Infrastructure.Data.Common;
using ExpeditionFuelsHub.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BillLadingServiceCollectionExtension
    {

         public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
             services.AddScoped<IRepository, Repository>();

            services.AddScoped<IBillLadingService, BillLadingService>();

              services.AddScoped<IFDispenserService, FdispenserService>();

             services.AddScoped<IGuard, Guard>();
            
            return services;
        }
    }
}
