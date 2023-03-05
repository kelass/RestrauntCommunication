using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restraunt.WebAPI.Controllers
{
    [Route("controller")]
    [Authorize]
    public class SecretController : ControllerBase
    {


        private readonly IHttpClientFactory _httpClientFactory;




        public SecretController()
        {
            

        }




        [Route("/Secret")]
        [HttpGet]
        public string Index()
        {
            var claims = User.Claims.ToList();
            return "secret";
        }


    }
}

