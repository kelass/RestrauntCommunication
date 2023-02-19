using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Restraunt.WebUI.Controllers
{
    
    public class PanelController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }
        [Authorize(Roles = "Waiter, Admin")]
        public IActionResult WaiterPanel()
        {
            return View();
        }

       
    }
}

