using Microsoft.AspNetCore.Mvc;
using Restraunt.Core;
using System.Security.Claims;

namespace Restraunt.WebUI.Controllers
{
    public class NotifyController : Controller
    {
        public IActionResult WaiterNotify()
        {
            var user = HttpContext.User;
            @ViewBag.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View();
        }
    }
}
