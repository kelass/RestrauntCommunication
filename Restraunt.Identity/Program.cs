
using System.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Identity.IdentityServer4;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("Secrets.json");
string connect = builder.Configuration.GetConnectionString("PersonalConnection");

builder.Services.AddIdentity<User, Role>(config =>
{
    config.Password.RequireUppercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;

})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "IdentityServer.Cookie";
    config.LoginPath = "/Account/Login";
    config.LogoutPath= "/Account/LogOut";
   
});
//Add google authentication
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {

        options.ClientId = "937172952204-tm8qh7anmv6dbifhsseslmi7mrlnqpni.apps.googleusercontent.com";
        options.ClientSecret = "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";
        options.ReturnUrlParameter = "/";

    });


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b => b.MigrationsAssembly("Restraunt.Data")));

//Localization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("uk")
                };
    options.DefaultRequestCulture = new RequestCulture("uk");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


builder.Services.AddIdentityServer()
      .AddAspNetIdentity<User>()
      .AddInMemoryApiResources(Configuration.GetApis())
      .AddInMemoryIdentityResources(Configuration.GetIdentityRecourses())
      .AddInMemoryClients(Configuration.GetClients())
      .AddDeveloperSigningCredential();


builder.Services.AddControllersWithViews().AddViewLocalization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
