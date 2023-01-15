using AirlinePricesNotificator.Services.AirlineWeb.Data;
using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using Ardalis.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.AirlineWeb.Repository.Imp
{
    public class Repository : IRepository
    {
        private readonly AirlineWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public Repository(AirlineWebDbContext dbContext, IMapper mapper)
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

        public async Task<Result<WebhookSubscriptionDto>> FindByIdAsync(int id)
        {
            var sub = await WebhookSubscriptions
                .ProjectTo<WebhookSubscriptionDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            return sub == null ?
                Result.NotFound() :
                sub;
        }

        public async Task<Result<WebhookSubscriptionDto>> CreateAsync(WebhookSubsriptionCreateDto dto)
        {
            var sub = _mapper.Map<WebhookSubscriptionDto>(dto);

            _dbContext.Add(sub);
            await _dbContext.SaveChangesAsync();
            return await FindByIdAsync(sub.Id);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var sub = WebhookSubscriptions
                .FirstOrDefaultAsync(x => x.Id == id);

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
