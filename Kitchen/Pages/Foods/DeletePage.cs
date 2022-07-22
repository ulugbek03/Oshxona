using Oshxona.Service.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Foods
{
    internal class DeletePage
    {
        public static async Task RunAsync()
        {
            try
            {

                int id = Prompt.Input<int>("Taom IDisini kiritng");

                IFoodRepository foodRepository = new FoodRepository();
                await foodRepository.DeleteAsync(id);

                System.Console.WriteLine("Ushbu taom o'chirildi.");

                await SubFooter.MakeFooterAsync();

            }
            catch (System.Exception)
            {

            }
        }
    }
}
