using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
using Restraunt.Data;
using Restraunt.Data.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("Secrets.json");
string connect = builder.Configuration.GetConnectionString("PersonalConnection");

//builder.Services.AddIdentity<User, Role>()
//.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b=> b.MigrationsAssembly("Restraunt.Data")));



            //Auth
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", config =>
    {
        config.Authority = "https://localhost:16819";
        config.Audience = "ApiOne";
        
    });

builder.Services.AddHttpClient();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:45591")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();

    });

});

builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<UnitOfWork>();


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


app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();


app.Run();