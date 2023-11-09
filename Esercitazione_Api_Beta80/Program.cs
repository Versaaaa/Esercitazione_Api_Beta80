using Esercitazione_Api_Beta80.Contexts;
using Esercitazione_Api_Beta80.Controllers;
using Esercitazione_Api_Beta80.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UtentiRepository, UtentiRepository>();
builder.Services.AddScoped<BancheRepository, BancheRepository>();
builder.Services.AddScoped<BancheFunzionalitaRepository, BancheFunzionalitaRepository>();
builder.Services.AddScoped<FunzionalitaRepository, FunzionalitaRepository>();

builder.Services.AddDbContext<BankomatContext>(cfg =>
{
    var connectionString = "Server=localhost\\SQLEXPRESS;Trusted_Connection=True;database=Bankomat";

    cfg.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();

});

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
