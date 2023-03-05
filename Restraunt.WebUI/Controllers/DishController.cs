using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restraunt.WebUI.Controllers
{
    public class DishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Completed()
        { 
            return View();

        }

        public async Task<IActionResult> Create()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
            return View();
        }




        public async Task<IActionResult> DishesAsync()
        {
           var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
           return View();
        }
    }
}
