using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobSocialNetwork.Controllers
{
    [Controller]
    public class AccountController : Controller
    {
        public readonly ApplicationService app;

        public AccountController(ApplicationService applicationService)
        {
            app = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await app.userRepository.Get().FirstOrDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);
            if (user != null)
            {
                await Authenticate(model.UserName);
                return RedirectToAction("Indexator", "Home");
            }
            ModelState.AddModelError("", "Incorrect UserName or password");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    City = model.City,
                    FirstName = model.FirstName,
                    Mail = model.Mail,
                    SecondName = model.SecondName
                };
                var state = await app.AddUserAsync(user);

                if (state == ApplicationService.StatesOfRegistration.Ok)
                {
                    await Authenticate(model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                if (state == ApplicationService.StatesOfRegistration.WrongEmail)
                {
                    ModelState.AddModelError("", "This UserName has already existed");
                }
                if (state == ApplicationService.StatesOfRegistration.WrongUserName)
                {
                    ModelState.AddModelError("", "This email has already registered");
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect entering data");
            }

            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
                };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
