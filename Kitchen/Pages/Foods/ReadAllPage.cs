using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Foods
{
    internal class ReadAllPage
    {
        public static async Task RunAsync()
        {
            ConsoleTable foodtable = new ConsoleTable("Id", "Nomi", "Turi", "Narxi");
            IFoodRepository foodRepository = new FoodRepository();
            var foods = await foodRepository.GetAllAsync();
            foreach (var food in foods)
            {
                foodtable.AddRow(food.Id, food.Name, food.FoodType, food.Price + " so'm");
            }
            foodtable.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
