using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastructure.Data.Entities;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.Models;
using ExpeditionFuelsHub.Core.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpeditionFuelsHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBillLadingService service;
        public HomeController(IBillLadingService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var bills=await this.service.GetLastTwoBillLadingAsync();
            return View(bills);
        }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}