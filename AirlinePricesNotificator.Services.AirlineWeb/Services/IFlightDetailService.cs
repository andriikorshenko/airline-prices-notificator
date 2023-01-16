using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using Ardalis.Result;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services
{
    public interface IFlightDetailService
    {
        IQueryable<FlightDetail> FlightDetails { get; }

        Task<Result<FlightDetailDto>> FindByCodeAsync(string code);

        Task<Result<FlightDetailDto>> CreateAsync(FlightDetailCreateDto dto);

        Task<Result> UpdateAsync(FlightDetailUpdateDto dto, int id);

        Task<Result> DeleteAsync(string secret);
    }
}
