using ExpeditionFuelsHub.Core.Constants;
using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Models.Admin;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await vehicleService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All), new { area="Admin"});
            }

              var vehicle = await vehicleService.VehicleDetailsById(id);

            var model = new VehicleModel()
            {
                Id = vehicle.Id,
                 VehicleRegistrationDocumentNumber = vehicle.VehicleRegistrationDocumentNumber,
                  RegistrationNumber = vehicle.RegistrationNumber,

                };

            return View(model);
        }

          [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleModel model)
        {
           if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

         
            if ((await vehicleService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Vehicle does not exist");

                return View(model);
            }

            string sanitizedRegNumber = this.SanitizeString(model.RegistrationNumber);
             string sanitizedVehNumber = this.SanitizeString(model.VehicleRegistrationDocumentNumber);
            if (string.IsNullOrEmpty(sanitizedRegNumber) || string.IsNullOrEmpty(sanitizedVehNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "Please don't try to XSS :)";
                
                return RedirectToAction("Edit", "Vehicle", new { area = "Admin" });
            }


            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await vehicleService.Edit(model.Id, model);

             TempData[MessageConstant.SuccessMessage] = "The Vehicle is eddid !";

            return RedirectToAction(nameof(All), new { model.Id });
        }

    }
}
