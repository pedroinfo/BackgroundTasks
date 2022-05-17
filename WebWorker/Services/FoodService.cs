using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebWorker.Models;
using WebWorker.Repositories;

namespace WebWorker.Services
{
    public class FoodService : IFoodService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IFoodRepository _foodRepository;
        public FoodService(IHttpClientFactory httpClientFactory, IFoodRepository foodRepository)
        {
            _httpClientFactory = httpClientFactory;
            _foodRepository = foodRepository;
        }

        public async Task<Food> GetFoodFromApi()
        {
            var urlFood = "https://random-data-api.com/api/food/random_food";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, urlFood);
            
            var httpClient = _httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("sad but true :(");
            }
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var food = await JsonSerializer.DeserializeAsync<Food>(contentStream, jsonSerializerOptions);

            return food;
        }


        public async Task<IList<Food>> GetAll()
        {
            return await _foodRepository.GetAll();
        }

        public async Task SaveFood(Food food)
        {
            await _foodRepository.Save(food);
        }

        public Task<int> CleanDatabase()
        {
            return _foodRepository.CleanDatabase();
        }
    }
}
