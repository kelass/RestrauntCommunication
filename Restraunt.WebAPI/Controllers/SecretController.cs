using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restraunt.WebAPI.Controllers
{
    public class SecretController : Controller
    {
        
        [Route("/secret")]
        [Authorize]
        public string Index()
        {
            return "secret";
        }
    }
}

