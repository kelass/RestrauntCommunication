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



        public IActionResult Create()
        {

            return View();
        }



        public IActionResult Dishes() => View();

    }
}
