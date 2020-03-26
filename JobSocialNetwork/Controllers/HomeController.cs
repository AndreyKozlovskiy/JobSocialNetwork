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
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
