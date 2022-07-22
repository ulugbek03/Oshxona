using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Foods
{
    internal class UpdatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            int id = Prompt.Input<int>("Taom IDisini kiriting");

            string Name = Prompt.Input<string>("Taom nomini kiriting");

            double Price = Prompt.Input<double>("Taom narxini kiriting");

            var types = Prompt.Select("Taom turini tanlang", new[] { "1.Fast Food", "2.Ichimlik", "3.Shirinlik", "4.Salatlar" });
            Enums.FoodType foodType = (Enums.FoodType)((int)types[0]) - 48;

            Food food = new Food()
            {
                Id = id,
                Name = Name,
                FoodType = foodType,
                Price = Price
            };


            IFoodRepository foodRepository = new FoodRepository();
            await foodRepository.UpdateAsync(id, food);
            Console.WriteLine("Taom muvaffaqiyatli yangilandi.");
            await SubFooter.MakeFooterAsync();


        }
    }
}
