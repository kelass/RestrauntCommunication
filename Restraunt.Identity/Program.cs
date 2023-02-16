using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Identity.IdentityServer4;

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

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b => b.MigrationsAssembly("Restraunt.Data")));


builder.Services.AddControllersWithViews();

builder.Services.AddIdentityServer()
      .AddAspNetIdentity<User>()
      .AddInMemoryApiResources(Configuration.GetApis())
      .AddInMemoryIdentityResources(Configuration.GetIdentityRecourses())
      .AddInMemoryClients(Configuration.GetClients())
      .AddDeveloperSigningCredential();

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
app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
