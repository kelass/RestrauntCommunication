using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
using Restraunt.Data;
using Restraunt.Data.Repositories;
using IdentityServer4.Models;
using Restraunt.WebAPI.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("Secrets.json");
string connect = builder.Configuration.GetConnectionString("PersonalConnection");




builder.Services.AddIdentity<User, Role>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b=> b.MigrationsAssembly("Restraunt.Data")));


//builder.Services.AddIdentityServer()
//    .AddInMemoryApiResources(Configuration.ApiResources)
//    .AddInMemoryIdentityResources(Configuration.IdentityResources)
//    .AddInMemoryApiScopes(Configuration.ApiScopes)
//    .AddInMemoryClients(Configuration.Clients)
//    .AddDeveloperSigningCredential();


builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<UnitOfWork>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

//app.Run(async (context)=>
//{
//    var response = context.Response;
//    var request = context.Request;
//    if(request.Path == "api/Dish")
//    {
//        var message = "Not valid value";

//        try
//        {
//            var dish = await request.ReadFromJsonAsync<Dish>();
//            if (dish != null)
//                message = $"Name: {dish.Name} Price: {dish.Price}";
//        }

//        catch
//        {
//            await response.WriteAsJsonAsync(new { text = message });
//        }
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html")
//    }
//}
//);
app.Run();