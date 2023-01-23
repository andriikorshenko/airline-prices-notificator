using AirlinePriceNotificator.Services.SendAgent.App;
using AirlinePriceNotificator.Services.SendAgent.App.Imp;
using AirlinePriceNotificator.Services.SendAgent.Client;
using AirlinePriceNotificator.Services.SendAgent.Client.Imp;
using AirlinePricesNotificator.Services.SendAgent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IAppHost, AppHost>();
        services.AddSingleton<IWebhookClient, WebhookClient>();
        services.AddDbContext<SendAgentDbContext>(opt => 
            opt.UseSqlServer(context.Configuration.GetConnectionString("DbConnection")));

        services.AddHttpClient();
    }).Build();

host.Services.GetService<IAppHost>().Run();