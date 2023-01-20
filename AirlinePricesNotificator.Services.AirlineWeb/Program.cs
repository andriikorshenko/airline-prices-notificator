using Microsoft.EntityFrameworkCore;
using AirlinePricesNotificator.Services.AirlineWeb.Data;
using AirlinePricesNotificator.Services.AirlineWeb.Services;
using AirlinePricesNotificator.Services.AirlineWeb.Services.Imp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IWebhookSubscriptionService, WebhookSubscriptionService>();
builder.Services.AddScoped<IFlightDetailService, FlightDetailService>();
builder.Services.AddSingleton<IMessageBusService, MessageBusService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
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
app.MapControllers();
app.UseStaticFiles();

app.Run();