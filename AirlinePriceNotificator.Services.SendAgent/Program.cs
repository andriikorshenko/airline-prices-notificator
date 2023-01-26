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
        services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build());

        services.AddSingleton<IAppHost, AppHost>();
        services.AddSingleton<IWebhookClient, WebhookClient>();
        
        services.AddDbContext<SendAgentDbContext>(options =>
            options.UseSqlServer(
                "Server=.;Database=AirlineWeb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True",
                sqlServerOptions => 
                    sqlServerOptions.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds)));

        services.AddHttpClient();
    }).Build();

host.Services.GetService<IAppHost>().Run();