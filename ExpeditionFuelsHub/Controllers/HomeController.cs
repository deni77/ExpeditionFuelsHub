using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Models;
using ExpeditionFuelsHub.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace ExpeditionFuelsHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBillLadingService service;
        private readonly ILogger<HomeController> logger; // w ka4enotio e bez HomeController

        public HomeController(IBillLadingService _service, ILogger<HomeController> _logger)
        {
            service = _service;
            logger=_logger;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            var bills=await this.service.GetLastTwoBillLadingAsync();
            return View(bills);
        }

     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return this.View(
        //        new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        //}
    }
}