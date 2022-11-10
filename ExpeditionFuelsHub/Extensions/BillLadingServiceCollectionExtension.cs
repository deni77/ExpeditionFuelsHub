using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BillLadingServiceCollectionExtension
    {

         public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBillLadingService, BillLadingService>();
            
            return services;
        }
    }
}
