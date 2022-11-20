using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Models.BillLading.Service;
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


        //[AllowAnonymous]
        //public async Task<IActionResult> All()
        //{
        //    var bills=await this.service.AllBillLadingAsync();
        //    return View(bills);
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllBillLadingQueryModel query)
        {
            TempData["OwnersBill"] = "0";
            var result = await service.All(
                query.Purpose,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllBillLadingQueryModel.BillLadingPerPage);

            query.TotalBillLadingCount = result.TotalBillLadingCount;
           query.Purposes = await service.AllPurposesNames();
            query.BillLadings = result.BillLadings;

            return View(query);
        }
        [Authorize(Roles ="Admin,Fdispenser")]
         public async Task<IActionResult> Mine()
        {
            IEnumerable<BillLadingServiceModel> myBillLadings=Enumerable.Empty<BillLadingServiceModel>();;
            var userId = User.Id();

            if (await fdispenserService.ExistsById(userId))
            {
                int fDispenserId = await fdispenserService.GetfDispecherId(userId);
                myBillLadings = await service.AllBillLadingsByFDispenserId(fDispenserId);
                TempData["OwnersBill"] = "1";
            }
            //else
            //{
            //    myBillLadings = await service.AllHousesByUserId(userId);
            //}

            return View(myBillLadings);
        }

        [AllowAnonymous]
         public async Task<IActionResult> Details(int id)
        {
           if ((await service.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await service.BillLadingDetailsById(id);

            return View(model);
        }

        [HttpGet]
          [Authorize(Roles ="Fdispenser")]
        public async Task<IActionResult> AddAsync()
        {
             if ((await fdispenserService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(FDispenserController.Become), "FDispenser",new { area=""});
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
                return RedirectToAction(nameof(FDispenserController.Become), "FDispenser",new { area=""});
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

            return RedirectToAction(nameof(Details),new { id } ); //new { id }
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
