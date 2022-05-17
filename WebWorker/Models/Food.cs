using LiteDB;
using System;

namespace WebWorker.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Dish { get; set; }
        public string Description { get; set; }
        public string Ingredient { get; set; }
        public string Measurement { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
