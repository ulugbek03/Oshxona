using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Foods
{

    public sealed class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            string Name = Prompt.Input<string>("Taom nomini kiriting");

            double Price = Prompt.Input<double>("Taom narxini kiriting");

            var types = Prompt.Select("Taom turini tanlang", new[] { "1.Fast Food", "2.Ichimlik", "3.Shirinlik", "4.Salatlar" });
            Enums.FoodType foodType = (Enums.FoodType)((int)types[0]) - 48;

            Food food = new Food()
            {
                Name = Name,
                Price = Price
            };


            IFoodRepository foodRepository = new FoodRepository();
            await foodRepository.CreateAsync(food);
            Console.WriteLine("Taom muvaffaqiyatli yaratildi.");
            await SubFooter.MakeFooterAsync();


        }
    }
}
