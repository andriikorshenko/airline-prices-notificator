using AirlinePricesNotificator.Services.TravelAgentWeb.Data;
using AirlinePricesNotificator.Services.TravelAgentWeb.Data.Entities;
using AirlinePricesNotificator.Services.TravelAgentWeb.Models;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Services.Imp
{
    public class NotificationsService : INotificationsService
    {
        private readonly TravelAgentDbContext _dbContext;

        public NotificationsService(TravelAgentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<WebhookSecret> WebhookSecrets => 
            _dbContext.Set<WebhookSecret>();

        public async Task<Result> FlightUpdatedAsync(FlightDetailUpdateDto dto)
        {
            Console.WriteLine($"Webhook recived from: {dto.Publisher}");

            var model = await WebhookSecrets
                .FirstOrDefaultAsync(x => x.Publisher == dto.Publisher &&
                                          x.Secret == dto.Secret);

            if (model == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invelid secret!");
                Console.ResetColor();
                return Result.NotFound();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Valid webhook!");
                Console.WriteLine($"Old price: {dto.OldPrice}, New price: {dto.NewPrice}");
                Console.ResetColor();
                return Result.Success();
            }
        }
    }
}
