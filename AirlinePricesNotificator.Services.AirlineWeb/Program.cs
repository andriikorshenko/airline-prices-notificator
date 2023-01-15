using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AirlinePricesNotificator.Services.AirlineWeb.Data;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using AirlinePricesNotificator.Services.AirlineWeb.Repository;
using AirlinePricesNotificator.Services.AirlineWeb.Repository.Imp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AirlineWebDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/webhook-subscription", (     
    WebhookSubsriptionCreateDto dto,
    IRepository repository,
    IMapper mapper) =>
{
    
})
.WithName("create");

app.Run();