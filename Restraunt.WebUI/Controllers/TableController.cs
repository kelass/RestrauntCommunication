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
  
    }
}
