using Microsoft.AspNetCore.Authentication;
using Restraunt.Core;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




//Auth
builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = "Cookie";
    config.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookie")
    .AddOpenIdConnect("oidc", config =>
    {
        config.Authority = "https://localhost:16819";
        config.ClientId = "client_id_mvc";
        config.ClientSecret = "client_secret_mvc";
        config.SaveTokens = true;

        config.ResponseType = "code";
        config.SignedOutCallbackPath = "/Home/Index";

        //configure cookie claims mapping 
        //config.ClaimActions.DeleteClaim("amr");
        //config.ClaimActions.DeleteClaim("s_hash");
        //config.ClaimActions.MapUniqueJsonKey("IdentityServer.RC", "rc.user");

        config.GetClaimsFromUserInfoEndpoint= true;

        //configure scope
        //config.Scope.Clear();
        config.Scope.Add("openid");
        config.Scope.Add("rc.scope");
        config.Scope.Add("ApiOne");

    });

builder.Services.AddHttpClient();

     builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
