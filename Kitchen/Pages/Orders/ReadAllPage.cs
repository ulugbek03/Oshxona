using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Orders
{
    internal class ReadAllPage
    {
        public static async Task RunAsync()
        {
            ConsoleTable table = new ConsoleTable("Mijoz ismi", "Taom nomlari", "Taom turilari", "Narxi");
            IOrderRepository orderRepository = new OrderRepository();

            var orders = await orderRepository.GetAllAsync();

            foreach (var order in orders)
            {
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

            }
            table.Write();
            await SubFooter.MakeFooterAsync();

        }
    }
}
