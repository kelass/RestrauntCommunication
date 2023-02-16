using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Restraunt.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var RefreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var claims = User.Claims.ToList();
            var _acessToken = new JwtSecurityTokenHandler().ReadJwtToken(access_token);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var result = await GetSecret(access_token);

            return Redirect("/");
        } 
        public IActionResult Register()
        {
            return View();
        }


        public async Task<string> GetSecret(string access_token)
        {
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(access_token);


            var response = await apiClient.GetAsync("https://localhost:7167/Secret");

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public IActionResult LogOut()
        {
            return SignOut("Cookie","oidc");
        }

    }
}
