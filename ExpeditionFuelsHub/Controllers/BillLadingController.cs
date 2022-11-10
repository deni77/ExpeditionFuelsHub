using ExpeditionFuelsHub.Core.Models.BillLading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Controllers
{
    [Authorize]
    public class BillLadingController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View(new AllBillLadingsViewModel());
        }

         public IActionResult Mine()
        {
            return View(new AllBillLadingsViewModel());
        }

         public IActionResult Details(int id)
        {
            return View(new DetailsBillLadingViewModel());
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddBillLadingViewModel model)
        {
            return RedirectToAction("Details", new { id = "1" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new AddBillLadingViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBillLadingViewModel model)
        {
            return  RedirectToAction(nameof(Details), new { id  });// id="1"
        }

        // public IActionResult Delete(int id)
        //{
        //    return View(new DetailsBillLadingViewModel());
        //}

        //[HttpPost]
        //public IActionResult Delete(DetailsBillLadingViewModel model)
        //{
        //    return RedirectToAction("all");
        //}

        //the gp vyrza za buton
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("All");
        }
    }
}
