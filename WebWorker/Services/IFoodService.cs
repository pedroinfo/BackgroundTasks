using System.Collections.Generic;
using System.Threading.Tasks;
using WebWorker.Models;

namespace WebWorker.Services
{
    public interface IFoodService
    {
        public Task<Food> GetFoodFromApi();
        public Task SaveFood(Food food);
        public Task<IList<Food>> GetAll();

        public Task<int> CleanDatabase();
    }
}
