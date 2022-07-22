using Oshxona.Data.Enums;

namespace Oshxona.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FoodType FoodType { get; set; }

        public double Price { get; set; }

    }
}
