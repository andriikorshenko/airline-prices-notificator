using AirlinePriceNotificator.Services.SendAgent.App;
using AirlinePriceNotificator.Services.SendAgent.App.Imp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IAppHost, AppHost>();
    }).Build();

host.Services.GetService<IAppHost>().Run();