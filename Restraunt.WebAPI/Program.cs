using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
using Restraunt.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("Secrets.json");
string connect = builder.Configuration.GetConnectionString("PersonalConnection");

builder.Services.AddIdentity<User, Role>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b=> b.MigrationsAssembly("Restraunt.WebAPI")));

builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
