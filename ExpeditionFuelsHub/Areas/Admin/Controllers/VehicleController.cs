using ExpeditionFuelsHub.Core.Constants;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Models.Admin;
using Ganss.Xss;
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
        [HttpGet]
         public async Task<IActionResult> Add()
        {
            var model = new VehicleModel();
           

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleModel model)
        {
            // nqkakvi proweerki ???
            if (!ModelState.IsValid)
            {
               return View(model);
            }

         
            //-sanitizer-------------------------------

            string sanitizedNUm = this.SanitizeString(model.VehicleRegistrationDocumentNumber);
            string sanitizedVeh = this.SanitizeString(model.RegistrationNumber);
            if (string.IsNullOrEmpty(sanitizedNUm) || string.IsNullOrEmpty(sanitizedVeh))
            {
                TempData[MessageConstant.ErrorMessage] = "Please don't try to XSS :)";

                return RedirectToAction("Add", "Vehicle", new { area = "Admin" });
            }

           
            int id = await vehicleService.Create(model);

            TempData[MessageConstant.SuccessMessage] = "New item is added !";

            return RedirectToAction(nameof(All)); //new { id }
        }

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
