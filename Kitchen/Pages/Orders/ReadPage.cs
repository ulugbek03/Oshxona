using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Orders
{
    internal class ReadPage
    {
        public static async Task RunAsync()
        {
            int id = Prompt.Input<int>("ID kiriting");
            ConsoleTable table = new ConsoleTable("Mijoz ismi", "Taom nomlari", "Taom turilari", "Narxi");
            IOrderRepository orderRepository = new OrderRepository();

            var order = await orderRepository.GetAsync(id);

            IClientRepository clientRepository = new ClientRepository();
            Client client = await clientRepository.GetAsync(order.ClientId);

            string ClientFullName = client.Id + ". " + client.FirstName + " " + client.LastName;
            string FoodsName = "";
            string FoodsType = "";
            double Money = 0;
            foreach (var item in order.FoodsId)
            {
                try
                {
                    IFoodRepository foodRepository = new FoodRepository();
                    Food food = await foodRepository.GetAsync(item);
                    if (food != null)
                    {
                        FoodsName += food.Name + " ";
                        FoodsType += food.FoodType.ToString() + " ";
                        Money += food.Price;
                    }


                }
                catch (System.Exception)
                {


                }
            }
            table.AddRow(ClientFullName, FoodsName, FoodsType, Money + " so'm");


            table.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
