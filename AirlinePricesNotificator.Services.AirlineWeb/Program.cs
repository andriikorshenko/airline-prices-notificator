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

app.MapGet("/api/webhook-subscriptions", async (
    IRepository repository) =>
{
    return await repository.AllAsync();
})
.WithName("GetAllSubscriptions");

app.MapGet("/api/webhook-subscriptions/{secret}", async (
    string secret,
    IRepository repository) =>
{
    var result = await repository.FindBySecretAsync(secret);
    return result.Value;
})
.WithName("GetSubscriptionBySecret");

app.MapPost("/api/webhook-subscriptions/create", async(     
    WebhookSubsriptionCreateDto dto,
    IRepository repository) =>
{
    var result = await repository.CreateAsync(dto);
    return result.Value;
})
.WithName("CreateSubscription");

app.Run();