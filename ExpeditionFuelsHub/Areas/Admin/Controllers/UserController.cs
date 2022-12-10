using ExpeditionFuelsHub.Core.Contracts.Admin;
using ExpeditionFuelsHub.Core.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpeditionFuelsHub.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUserService userService;

        public UserController(
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager,
            IUserService _userService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            userService = _userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "BillLading", new { area = "" });
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {// ako sled register трябва да логваме User
             // await signInManager.SignInAsync(user, isPersistent: false);
             // return RedirectToAction("All", "Movies");

                return RedirectToAction("Login", "User", new { area = "Admin" });
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "BillLading", new { area = "" });
                // return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel() { };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("All", "BillLading",new { area=""});
                //}
                if (result.Succeeded && await userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("All", "BillLading", new { area = "" });
                }
            }

            ModelState.AddModelError("", "Invalid login !");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.All();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole()
        {
            var model = await userService.AssignRole();

            return View(model);
        }
      
        public async Task<IActionResult> AssignToRole(string userid)
        {
            await userService.AssignToRole( userid);

            return RedirectToAction("All", "User", new { area = "Admin" });
        }
    }
}
