using AirlinePricesNotificator.Services.SendAgent.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AirlinePriceNotificator.Services.SendAgent.Client.Imp
{
    public class WebhookClient : IWebhookClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebhookClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendWebhookNotification(FlightDetailChangePayloadDto dto)
        {
            var serializedPayload = JsonSerializer.Serialize(dto);

            var httpClient = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, dto.WebhookUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedPayload);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                using (var response = await httpClient.SendAsync(request))
                {
                    Console.WriteLine("Success!");
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
