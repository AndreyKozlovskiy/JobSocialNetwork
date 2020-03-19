using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSocialNetwork
{
    public class HomeController : Controller
    {
        public readonly ApplicationService applicationService;
        public HomeController(ApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        // GET: /<controller>/
        public async Task<string> Index()
        {
            
            var user = new User() { City = "BOR", SecondName = "KI", FirstName = "VAC", Mail = "AW", Password = "123", UserName = "FCXZ" };
            await applicationService.userService.AddAsync(user);
           
            return applicationService.ToString();
        }
    }
}
