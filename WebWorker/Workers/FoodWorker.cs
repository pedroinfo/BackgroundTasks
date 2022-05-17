using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebWorker.Services;

namespace WebWorker.Workers
{
    public class FoodWorker : BackgroundService
    {

        private readonly ILogger<FoodWorker> _foodWorkerLogger;

        private readonly IFoodService _foodService;

        public FoodWorker(ILogger<FoodWorker> foodWorkerLogger, IServiceScopeFactory factory)
        {
            _foodWorkerLogger = foodWorkerLogger;
            _foodService = factory.CreateScope().ServiceProvider.GetRequiredService<IFoodService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _foodWorkerLogger.LogDebug("Starting FoodWorker");

            while (!stoppingToken.IsCancellationRequested)
            {
                await RegisterFood();
            }
            _foodWorkerLogger.LogDebug("Finished FoodWorker");
        }


        private async Task RegisterFood()
        {
            var newFoodFromApi = await _foodService.GetFoodFromApi();

            await _foodService.SaveFood(newFoodFromApi);

            await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}
