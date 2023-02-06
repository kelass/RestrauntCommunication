using System.Data;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b => b.MigrationsAssembly("Restraunt.Data")));


builder.Services.AddControllersWithViews();

//builder.Services.AddIdentityServer()
//    .AddInMemoryApiResources(Configuration.ApiResources)
//    .AddInMemoryIdentityResources(Configuration.IdentityResources)
//    .AddInMemoryApiScopes(Configuration.ApiScopes)
//    .AddInMemoryClients(Configuration.Clients)
//    .AddDeveloperSigningCredential();

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
//app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
