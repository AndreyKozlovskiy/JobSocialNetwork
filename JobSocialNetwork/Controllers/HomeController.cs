using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSocialNetwork
{
    public class HomeController : Controller
    {
        public readonly ApplicationService app;

        public HomeController(ApplicationService applicationService)
        {
            app = applicationService;
        }

        [HttpGet]
        public async Task<string> Index()
        {
            var user = new User() { FirstName = "Andrey", SecondName = "Kozlovskiy", Password = "12345678", City = "Monako", Mail = "car@gmail.com", UserName = "caratos" };
            await app.AddUserAsync(user);
            return app.userService.Get(user.Id).UserName;
        }
    }
}
