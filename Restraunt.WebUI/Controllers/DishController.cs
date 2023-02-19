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

        public IActionResult Completed(Guid Id)
        {
            return RedirectToAction("Dishes","Dish");
        }

        public async Task<IActionResult> Create()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
            return View();
        }



        public IActionResult Dishes() => View();

    }
}
