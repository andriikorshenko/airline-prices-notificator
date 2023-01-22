using AirlinePriceNotificator.Services.SendAgent.App;
using AirlinePriceNotificator.Services.SendAgent.App.Imp;
using AirlinePricesNotificator.Services.SendAgent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IAppHost, AppHost>();
        services.AddDbContext<SendAgentDbContext>(opt => 
            opt.UseSqlServer(context.Configuration.GetConnectionString("DbConnection")));
    }).Build();

host.Services.GetService<IAppHost>().Run();