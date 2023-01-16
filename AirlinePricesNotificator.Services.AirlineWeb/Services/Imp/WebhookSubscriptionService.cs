using AirlinePricesNotificator.Services.AirlineWeb.Data;
using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using Ardalis.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services.Imp
{
    public class WebhookSubscriptionService : IWebhookSubscriptionService
    {
        private readonly AirlineWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public WebhookSubscriptionService(AirlineWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IQueryable<WebhookSubscription> WebhookSubscriptions => 
            _dbContext.Set<WebhookSubscription>();

        public async Task<IReadOnlyList<WebhookSubscriptionDto>> AllAsync()
        {
            return await WebhookSubscriptions
                .ProjectTo<WebhookSubscriptionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Result<WebhookSubscriptionDto>> FindBySecretAsync(string secret)
        {
            var sub = await WebhookSubscriptions
                .ProjectTo<WebhookSubscriptionDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Secret == secret);

            return sub == null ?
                Result.NotFound() :
                sub;
        }

        public async Task<Result<WebhookSubscriptionDto>> CreateAsync(WebhookSubsriptionCreateDto dto)
        {
            var sub = _mapper.Map<WebhookSubscription>(dto);
            sub.Secret = Guid.NewGuid().ToString();
            sub.WebhookPublisher = "WizzAir"; //Just for a test...

            _dbContext.Add(sub);
            await _dbContext.SaveChangesAsync();
            return await FindBySecretAsync(sub.Secret);
        }

        public async Task<Result> DeleteAsync(string secret)
        {
            var sub = await WebhookSubscriptions
                .FirstOrDefaultAsync(x => x.Secret == secret);

            if (sub == null)
            {
                return Result.NotFound();
            }

            _dbContext.Remove(sub);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }        
    }
}
