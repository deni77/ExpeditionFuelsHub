using ExpeditionFuelsHub.Models.FDispenser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Controllers
{
    [Authorize]
    public class FDispenserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            //if (await agentService.ExistsById(User.Id()))
            //{
            //    TempData[MessageConstant.ErrorMessage] = "Вие вече сте Агент";

            //    return RedirectToAction("Index", "Home");
            //}

            var model =  new BecomeFDispenserViewModel();

            return View(model);
        }


       [HttpPost]
        public async Task<IActionResult> Become(BecomeFDispenserViewModel model)
        {
            return  RedirectToAction("All","BillLading"); // ?????
        }
    }
}
