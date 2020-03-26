using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobSocialNetwork.Controllers
{
    public class AccountContoller : Controller
    {
        public readonly ApplicationService app;

        public AccountContoller(ApplicationService applicationService)
        {
            app = applicationService;
        }

        [HttpGet]
        public string Login()
        {
            return "Bye";
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await app.GetUserByName(model.UserName);
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        await Authenticate(model.UserName);

                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Incorrect UserName or password");
            }
            return View(model);
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
