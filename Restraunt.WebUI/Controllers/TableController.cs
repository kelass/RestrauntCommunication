using Microsoft.AspNetCore.Mvc;
using Restraunt.Core.Dto;

namespace Restraunt.WebUI.Controllers
{
    public class TableController : Controller
    {

        public IActionResult Create(TableDto model )
        { 
           

            return View();
        }

        public IActionResult Manu()
        {
            return View();
        }

        public IActionResult Menu(Guid id)
        {
            return View();
        }

    }
}
