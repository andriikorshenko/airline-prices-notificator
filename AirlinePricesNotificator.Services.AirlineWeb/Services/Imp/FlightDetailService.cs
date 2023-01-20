using AirlinePricesNotificator.Services.AirlineWeb.Data;
using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using Ardalis.Result;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services.Imp
{
    public class FlightDetailService : IFlightDetailService
    {
        private readonly AirlineWebDbContext _dbContext;
        private readonly IMessageBusService _messageBusService;
        private readonly IMapper _mapper;

        public FlightDetailService(
            AirlineWebDbContext dbContext, 
            IMessageBusService messageBusService, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _messageBusService = messageBusService;
            _mapper = mapper;
        }

        public IQueryable<FlightDetail> FlightDetails =>
            _dbContext.Set<FlightDetail>();

        public async Task<Result<FlightDetailDto>> FindByCodeAsync(string code)
        {
            var flight = await FlightDetails
                .ProjectTo<FlightDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.FlightCode == code);

            return flight == null ?
               Result.NotFound() :
               flight;
        }

        public async Task<Result<FlightDetailDto>> CreateAsync(FlightDetailCreateDto dto)
        {
            var flight = _mapper.Map<FlightDetail>(dto);

            _dbContext.Add(flight);
            await _dbContext.SaveChangesAsync();
            return await FindByCodeAsync(flight.FlightCode);
        }

        public async Task<Result> UpdateAsync(FlightDetailUpdateDto dto, int id)
        {
            var flight = await FlightDetails
                .FirstOrDefaultAsync(x => x.Id == id);

            if (flight == null)
            {
                return Result.NotFound();
            }

            decimal oldPrice = flight.Price;

            _mapper.Map(dto, flight);
            await _dbContext.SaveChangesAsync();

            if (oldPrice != flight.Price)
            {
                Console.WriteLine("Price Changed - Please send on bus");

                var message = new NotificationMessageDto()
                {
                    WebhookType = "pricechange",
                    OldPrice = oldPrice,
                    NewPrice = flight.Price,
                    FlightCode = flight.FlightCode
                };
                _messageBusService.SendMessage(message);
            }
            else 
            {
                Console.WriteLine("No Price Change");
            }

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(string code)
        {
            var flight = await FlightDetails
                .FirstOrDefaultAsync(x => x.FlightCode == code);

            if (flight == null)
            {
                return Result.NotFound();
            }

            _dbContext.Remove(flight);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }        
    }
}
