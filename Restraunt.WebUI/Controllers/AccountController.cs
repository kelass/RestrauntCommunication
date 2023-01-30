using Microsoft.AspNetCore.Mvc;

namespace Restraunt.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
