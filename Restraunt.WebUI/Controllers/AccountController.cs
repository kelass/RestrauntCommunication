using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

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

            // //retrieve access token
            // var serverClient = _httpClientFactory.CreateClient();


            // var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:16819/");

            //var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            // {
            //    Address = discoveryDocument.TokenEndpoint,
            //    ClientId = "client_id",
            //    ClientSecret = "client_secret",

            //    Scope = "ApiOne",
            // });

            // //retrieve secret data
            // var apiClient = _httpClientFactory.CreateClient();

            // apiClient.SetBearerToken(tokenResponse.AccessToken);


            //var response = await apiClient.GetAsync("https://localhost:7167/Secret");

            //var content = await response.Content.ReadAsStringAsync();

            // return Ok(new
            // {
            //    access_token = tokenResponse.AccessToken,
            //    message = content
            // });
            var access_token = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var RefreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var claims = User.Claims.ToList();
            var _acessToken = new JwtSecurityTokenHandler().ReadJwtToken(access_token);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var result = await GetSecret(access_token);

            return View();
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

    }
}
