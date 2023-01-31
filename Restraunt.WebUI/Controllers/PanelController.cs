using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Restraunt.WebUI.Controllers
{
    public class PanelController : Controller
    {
      
        public IActionResult AdminPanel()
        {
            return View();
        } 
        public IActionResult WaiterPanel()
        {
            return View();
        }

       
    }
}

