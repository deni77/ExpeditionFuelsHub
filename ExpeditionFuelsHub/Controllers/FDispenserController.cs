using ExpeditionFuelsHub.Core.Constants;
using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Models.FDispenser;
using ExpeditionFuelsHub.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Controllers
{
    [Authorize]
    public class FDispenserController : Controller
    {
        private readonly IFDispenserService service;
        public FDispenserController(IFDispenserService _service)
        {
            service = _service;
        }

      
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await service.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече сте Стоковед !";

                return RedirectToAction("Index", "Home",new { area=""} );
            }

            var model = new BecomeFDispenserViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Become(BecomeFDispenserViewModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече сте Стоковед !";
               // ModelState.AddModelError();

                return RedirectToAction("Index", "Home",new { area=""});
            }

            if (await service.UserWithPhoneNumberExists(model.PhoneNumber))
            {
               TempData[MessageConstant.ErrorMessage] = "Телефона вече съществува";

                // return RedirectToAction("Index", "Home");
                return View(model);
            }

            await service.Create(userId, model.PhoneNumber);

            await service.AddToRoleFDispenser(userId);

            return RedirectToAction("All", "BillLading",new { area=""});
        }
    }
}
