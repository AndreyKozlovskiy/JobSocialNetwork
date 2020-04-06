using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationService app;

        public HomeController(ApplicationService applicationService)
        {
            app = applicationService;
        }

        [Authorize]
        public async Task<string> Indexator()
        {
            var user = User.Identity;
            return user.Name;
        }
        
        public async Task<string> Index()
        {
            return "Hi";
        }

    }
}
