using System.Collections.Generic;
using System.Threading.Tasks;
using WebWorker.Models;

namespace WebWorker.Repositories
{
    public interface IFoodRepository
    {
        public Task<Food> Save(Food food);

        public Task<IList<Food>> GetAll();

        public Task<int> CleanDatabase();
    }
}
