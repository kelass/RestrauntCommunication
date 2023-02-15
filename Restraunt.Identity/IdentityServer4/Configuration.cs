using System;
using System.Reflection.Metadata.Ecma335;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using static System.Net.WebRequestMethods;

namespace Restraunt.Identity.IdentityServer4
{
	public static class Configuration
	{
		public static IEnumerable<IdentityResource> GetIdentityRecourses() =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),

				new IdentityResource
				{
					Name = "rc.scope",
					UserClaims =
					{
                        "rc.user"
                    }
				}
			};

		public static IEnumerable<ApiResource> GetApis() =>
			new List<ApiResource>
			{
				new ApiResource("ApiOne", new string[] {"rc.api"}),
				new ApiResource("ApiTwo")
			};

		public static IEnumerable<Client> GetClients() =>
			new List<Client>
			{
				new Client
				{
					ClientId="client_id",
					ClientSecrets={ new Secret("client_secret".ToSha256())},
					AllowedGrantTypes = GrantTypes.ClientCredentials,

					AllowedScopes = {"ApiOne"}
					
				},


                new Client
                {
                    ClientId="client_id_mvc",
                    ClientSecrets={ new Secret("client_secret_mvc".ToSha256())},
                    AllowedGrantTypes = GrantTypes.Code,
					RedirectUris = {"https://localhost:45591/signin-oidc"},
                    AllowedScopes = 
					{
						"ApiOne",
						"ApiTwo", 
						IdentityServerConstants.StandardScopes.OpenId,

						IdentityServerConstants.StandardScopes.Profile,
						"rc.scope"
                    },
					
					//puts all the claims in the id token
					AlwaysIncludeUserClaimsInIdToken= true,

					RequireConsent = false

                }

            };

		
	}
}

