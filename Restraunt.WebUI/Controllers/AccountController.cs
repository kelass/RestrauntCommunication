using Microsoft.AspNetCore.Mvc;

namespace Restraunt.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Login()
        {

            //retrieve access token
            var serverClient = _httpClientFactory.CreateClient();

            //retrieve secret data


            return Ok(new
            {

            });
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
