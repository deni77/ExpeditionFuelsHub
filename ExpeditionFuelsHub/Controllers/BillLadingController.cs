using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Controllers
{
    [Authorize]
    public class BillLadingController : Controller
    {
        private readonly IBillLadingService service;
          private readonly IFDispenserService fdispenserService;
        public BillLadingController(IBillLadingService _service, IFDispenserService _fdispenserService)
        {
            service = _service;
            fdispenserService = _fdispenserService; 
        }


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
        public async Task<IActionResult> AddAsync()
        {
             if ((await fdispenserService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(FDispenserController.Become), "FDispenser");
            }

            var model = new AddBillLadingViewModel()
            {
                BillsDistributions = await service.AllDistributionChanels(),
                 BillsProducts=await service.AllProducts(),
                  BillsPurposes=await service.AllPurposes(),
                   BillsVehicles=await service.AllVehicles()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBillLadingViewModel model)
        {
            if ((await fdispenserService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(FDispenserController.Become), "FDispenser");
            }

            if ((await service.DistributionChanelExists(model.DistributionChanelId)) == false)
            {
                ModelState.AddModelError(nameof(model.DistributionChanelId), "Distribution Chanel does not exists");
            }

             if ((await service.ProductExists(model.ProductId)) == false)
            {
                ModelState.AddModelError(nameof(model.ProductId), "Product does not exists");
            }

              if ((await service.PurposeExists(model.PurposeId)) == false)
            {
                ModelState.AddModelError(nameof(model.PurposeId), "Purpose does not exists");
            }

               if ((await service.VehicleExists(model.VehicleId)) == false)
            {
                ModelState.AddModelError(nameof(model.VehicleId), "Vehicle does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.BillsDistributions = await service.AllDistributionChanels();
                model.BillsPurposes=await service.AllPurposes();
                model.BillsProducts = await service.AllProducts();
                model.BillsVehicles = await service.AllVehicles();

                return View(model);
            }

            int fDispecherId = await fdispenserService.GetfDispecherId(User.Id());

            int id = await service.Create(model, fDispecherId);

            return RedirectToAction(nameof(Details), new { id });
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var model = new AddBillLadingViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, AddBillLadingViewModel model)
        //{
        //    return  RedirectToAction(nameof(Details), new { id  });// id="1"
        //}

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
