using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace DanFestaJuninaCore.Models
{
    public class GolangDishRepository : IDishRepository
    {
        public Task<IEnumerable<Dish>> _dishList { get; private set; }
        public bool GetDishesError { get; private set; }

        private HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        private IOptions<DanAppSettings> danappsettings; 

        public GolangDishRepository(IOptions<DanAppSettings> settings)
        {
            danappsettings = settings;
        }

        async Task<IEnumerable<Dish>> IDishRepository.GetAllDishes(IOptions<DanAppSettings> settings)
        {
            //var requestUrl = "http://localhost:1610/dishlist";
            var requestUrl = settings.Value;

            // requestUrl.DanAPIServiceDishes = "http://192.168.2.120:1610/dishlist";
            // MSAPIdishesIPAddress

            var fullurl = requestUrl.MSAPIdishesIPAddress + "dishlist";
            //fullurl = "https://localhost:7184/dishes";

            System.Uri su = new Uri(fullurl);

            _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync(su);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var conv = JsonConvert.DeserializeObject<List<Dish>>(data);

            return conv;
        }
        async Task<IEnumerable<Dish>> IDishRepository.GetAllDishesdotnet(IOptions<DanAppSettings> settings)
        {
            //var requestUrl = "http://localhost:1610/dishlist";
            var requestUrl = settings.Value;

            // requestUrl.DanAPIServiceDishes = "http://192.168.2.120:1610/dishlist";
            // MSAPIdishesIPAddress

            var fullurl = requestUrl.MSAPIdishesIPAddress + "/Dishes/dishlist";
            fullurl = "https://localhost:7184/dishes";

            System.Uri su = new Uri(fullurl);

            _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync(su);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var conv = JsonConvert.DeserializeObject<List<Dish>>(data);

            return conv;
        }

        public async Task<Dish> GetDish(string Name)
        {

            var appsettings = danappsettings.Value;

            //System.Uri su = new Uri(appsettings.DanAPIServiceDishes);

            var urifull = string.Concat(appsettings.MSAPIdishesIPAddress, "/dishList");
            System.Uri su = new Uri(urifull);

            _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync(su);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var conv = JsonConvert.DeserializeObject<Dish>(data);

            return conv;
        }

        /// <summary>
        /// Send a PUT request toi update a DISH
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        public async Task<Dish> UpdateDish(Dish dish)
        {

            Dish dishnew = new()
            {
                Name = dish.Name,
                Type = dish.Type,
                Price = dish.Price,
                GlutenFree = dish.GlutenFree,
                DairyFree = dish.DairyFree,
                Vegetarian = dish.Vegetarian,
                InitialAvailable = dish.InitialAvailable,
                CurrentAvailable = dish.CurrentAvailable,
                ImageName = dish.ImageName,
                Description = dish.Description,
                Descricao = dish.Descricao,
                ActivityType = dish.ActivityType,
                ImageBase64 = ""
            };

            var appsettings = danappsettings.Value;

            var urifull = string.Concat(appsettings.MSAPIdishesIPAddress, dish.Id);

            System.Uri uri = new Uri(urifull);


            // using System.Text.Json
            var newdishjson = System.Text.Json.JsonSerializer.Serialize(dishnew);            
  
            var requestContent = new StringContent(newdishjson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, requestContent);
            response.EnsureSuccessStatusCode();

            return dish;
        }

        //private HttpContent CreateHttpContent<T>(T content)
        //{
        //    var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
        //    return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //}

    }
}
