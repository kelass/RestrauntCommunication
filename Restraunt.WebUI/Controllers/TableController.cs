using Microsoft.AspNetCore.Mvc;

namespace Restraunt.WebUI.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
