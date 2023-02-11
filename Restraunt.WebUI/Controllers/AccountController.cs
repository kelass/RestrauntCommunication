using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
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


            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:16819/");

           var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
               Address = discoveryDocument.TokenEndpoint,
               ClientId = "client_id",
               ClientSecret = "client_secret",

               Scope = "ApiOne",
            });

            //retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


           var response = await apiClient.GetAsync("https://localhost:7167/Secret");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
               access_token = tokenResponse.AccessToken,
               message = content
            });
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
