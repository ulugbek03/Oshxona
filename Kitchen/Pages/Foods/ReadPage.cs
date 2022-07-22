using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Foods
{
    internal class ReadPage
    {
        public static async Task RunAsync()
        {
            int id = Prompt.Input<int>("Taom IDisini kiritng");

            IFoodRepository foodRepository = new FoodRepository();
            var food = await foodRepository.GetAsync(id);


            ConsoleTable table = new ConsoleTable("Id", "Nomi", "Turi", "Narxi");
            table.AddRow(food.Id, food.Name, food.FoodType.ToString(), food.Price + " so'm");

            table.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
