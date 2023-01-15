using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using AutoMapper;

namespace AirlinePricesNotificator.Services.AirlineWeb.Profiles
{
    public class WebhookSubscriptionProfile : Profile
    {
        public WebhookSubscriptionProfile()
        {
            //Source -> Target
            CreateMap<WebhookSubscription, WebhookSubscriptionDto>();
            CreateMap<WebhookSubsriptionCreateDto, WebhookSubscription>();
        }
    }
}
