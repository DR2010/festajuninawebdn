using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.Models
{
    public class KrakenRepository : IKrakenRepository
    {
        public Task<IEnumerable<Dish>> _dishList { get; private set; }
        public bool GetDishesError { get; private set; }

        private HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        private IOptions<DanAppSettings> danappsettings; 

        public KrakenRepository(IOptions<DanAppSettings> settings)
        {
            danappsettings = settings;
        }

        async Task<string> IKrakenRepository.GetTime(IOptions<DanAppSettings> settings)
        {
            //var requestUrl = "http://localhost:1610/dishlist";
            // https://api.kraken.com/0/public/SystemStatus

            var requestUrl = settings.Value;

            // requestUrl.DanAPIServiceDishes = "http://192.168.2.120:1610/dishlist";
            // MSAPIdishesIPAddress

            var fullurl = requestUrl.KrakenAPI + "/SystemStatus";

            System.Uri su = new Uri(fullurl);

            _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync(su);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var conv = JsonConvert.DeserializeObject<string>(data);

            return conv;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

    }
}
