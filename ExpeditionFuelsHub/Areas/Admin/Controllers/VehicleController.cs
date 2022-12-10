using ExpeditionFuelsHub.Core.Contracts.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Areas.Admin.Controllers
{
     [Authorize]
    [Area("Admin")]
    public class VehicleController : Controller
    {
    private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService _vehicleService)
        {
            vehicleService = _vehicleService;
        }
        public async Task<IActionResult> All()
        {
            var model = await vehicleService.All();

            return View(model);
        }
    }
}
