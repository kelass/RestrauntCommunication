using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Restraunt.WebAPI.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Restraunt.WebAPI", "Web API")
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("Restraunt.WebAPI", "Web API",
                    new [] {JwtClaimTypes.Name})
                {
                    Scopes = {"Restraunt.WebAPI"}

                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "restraunt-web-api",
                    ClientName = "Restraunt web api",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://localhost:7165"
                    },

                   AllowedCorsOrigins =
                    {
                        "http://localhost:7165/Account/Register",
                        "http://localhost:7165/Account/Login"
                    },
                   PostLogoutRedirectUris =
                    {
                        "http://localhost:7165"
                    },
                   AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Restraunt.WebAPI"
                    },

                   AllowAccessTokensViaBrowser= true
                    
                }
            };
    }
}
