using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorker.Models;

namespace WebWorker.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly string DatabaseLocation = @"Filename=C:\Temp\MyData.db; Connection=Shared;";
       
        public async Task<Food> Save(Food food)
        {
            using var db = new LiteDatabase(DatabaseLocation);
            var col = db.GetCollection<Food>("food");

            var result = col.Insert(food);

            return await Task.FromResult(food);
        }

        public async Task<IList<Food>> GetAll()
        {
            using var db = new LiteDatabase(DatabaseLocation);
            var col = db.GetCollection<Food>("food");

            var result = col.FindAll().ToList();

            return await Task.FromResult(result);
        }

        public async Task<int> CleanDatabase()
        {
            using var db = new LiteDatabase(DatabaseLocation);
            var col = db.GetCollection<Food>("food");

            var result = col.DeleteAll();

            return await Task.FromResult(result);
        }
    }
}
