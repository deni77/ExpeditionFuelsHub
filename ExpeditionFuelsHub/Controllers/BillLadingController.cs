using ExpeditionFuelsHub.Core.Constants;
using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Core.Models.BillLading;
using ExpeditionFuelsHub.Core.Models.BillLading.Service;
using ExpeditionFuelsHub.Extensions;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using Ganss.Xss;
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
            
            return View(myBillLadings);
        }

        [AllowAnonymous]
         public async Task<IActionResult> Details(int id)
        {
           //if ((await service.Exists(id)) == false)
           // {
           //     return RedirectToAction(nameof(All));
           // }

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

            //-sanitizer-------------------------------
            string sanitizedImageUrl = this.SanitizeString(model.ImageUrl);
            if (string.IsNullOrEmpty(sanitizedImageUrl))
            {
                this.TempData[MessageConstant.ErrorMessage] = "Please don't try to XSS :)";

                 model.BillsDistributions = await service.AllDistributionChanels();
                model.BillsPurposes=await service.AllPurposes();
                model.BillsProducts = await service.AllProducts();
                model.BillsVehicles = await service.AllVehicles();
                
                return RedirectToAction("Add", "BillLading", new { area = "" });
            }

            model.ImageUrl = sanitizedImageUrl;

            int id = await service.Create(model, fDispecherId);

            TempData[MessageConstant.SuccessMessage] = "New BillLading is added !";

            return RedirectToAction(nameof(Details),new { id } ); //new { id }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await service.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All), new { area=""});
            }

            if ((await service.HasFDispenserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var bill = await service.BillLadingDetailsById(id);
            var purposeId = await service.GetBillLadingByPurposeId(id); 
            var productId = await service.GetBillLadingProductId(id);
            var vehicleId = await service.GetBillLadingVehicleId(id);
            var distributionchannelId = await service.GetBillLadingVehicleId(id); //????????????

            var model = new AddBillLadingViewModel()
            {
                Id = bill.Id,
                GrossStandartVolume = bill.GrossStandardVolume,
                PurposeId = purposeId,
                Mass = bill.Mass,
                ImageUrl = bill.ImageUrl,
               // CreatedOn =  DateTime.ParseExact(bill.CreatedOn, "dd-MM=yyyy HH:mm:ss",
                                      // System.Globalization.CultureInfo.InvariantCulture),
                VehicleId = vehicleId,
                ProductId =productId,
              DistributionChanelId = distributionchannelId,
                BillsProducts  = await service.AllProducts(),
                BillsDistributions = await service.AllDistributionChanels(),
                BillsPurposes = await service.AllPurposes(),
                BillsVehicles = await service.AllVehicles()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBillLadingViewModel model)
        {
           if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

         
            if ((await service.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "BillLading does not exist");
                model.BillsVehicles = await service.AllVehicles();
                model.BillsPurposes = await service.AllPurposes();
                model.BillsProducts = await service.AllProducts();
                model.BillsDistributions = await service.AllDistributionChanels();

                return View(model);
            }

            if ((await service.HasFDispenserWithId(model.Id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await service.PurposeExists(model.PurposeId)) == false)
            {
                ModelState.AddModelError(nameof(model.PurposeId), "Purpose does not exist");
                 model.BillsPurposes = await service.AllPurposes();

                return View(model);
            }

            if ((await service.ProductExists(model.ProductId)) == false)
            {
                ModelState.AddModelError(nameof(model.ProductId), "Product does not exist");
                 model.BillsProducts = await service.AllProducts();

                return View(model);
            }
            if ((await service.DistributionChanelExists(model.DistributionChanelId)) == false)
            {
                ModelState.AddModelError(nameof(model.DistributionChanelId), "DistributionChanel does not exist");
                 model.BillsDistributions= await service.AllDistributionChanels();

                return View(model);
            }

            if ((await service.VehicleExists(model.VehicleId)) == false)
            {
                ModelState.AddModelError(nameof(model.VehicleId), "Vehicle does not exist");
                 model.BillsVehicles= await service.AllVehicles();

                return View(model);
            }

            string sanitizedImageUrl = this.SanitizeString(model.ImageUrl);
            if (string.IsNullOrEmpty(sanitizedImageUrl))
            {
                TempData[MessageConstant.ErrorMessage] = "Please don't try to XSS :)";

                model.BillsDistributions = await service.AllDistributionChanels();
                model.BillsPurposes = await service.AllPurposes();
                model.BillsProducts = await service.AllProducts();
                model.BillsVehicles = await service.AllVehicles();

                return RedirectToAction("Edit", "BillLading", new { area = "" });
            }


            if (ModelState.IsValid == false)
            {
                model.BillsPurposes = await service.AllPurposes();
                model.BillsDistributions = await service.AllDistributionChanels();
                model.BillsVehicles = await service.AllVehicles();
                model.BillsProducts = await service.AllProducts();

                return View(model);
            }

            await service.Edit(model.Id, model);

             TempData[MessageConstant.SuccessMessage] = "The BillLading is edded !";

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await service.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All), new { area=""});
            }

            if ((await service.HasFDispenserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var bill = await service.BillLadingDetailsById(id);
            var model = new DetailsBillLadingViewModel()
            {
                 Mass=bill.Mass,
                  GrossStandardVolume=bill.GrossStandardVolume,
                ImageUrl = bill.ImageUrl,
                 Product=bill.Product
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DetailsBillLadingViewModel model)
        {
            if ((await service.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All), new { area=""});
            }

            if ((await service.HasFDispenserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await service.Delete(id);

            return RedirectToAction(nameof(All), new { area=""});
        }
        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
