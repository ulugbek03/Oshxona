using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Linq;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Orders
{
    internal class CreatePage
    {
        public static async Task RunAsync()
        {
            Order order = new Order();
            order.OrderDate = System.DateTime.Now;
            int ClId = Prompt.Input<int>("Mijoz IDisini kiriting");

            order.ClientId = ClId;

            int n = Prompt.Input<int>("Nechta taom sotib olasiz");

            order.Money = 0;
            for (int i = 0; i < n; i++)
            {

                int id = Prompt.Input<int>($"{i + 1}-Taom IDisini kiriting");
                order.FoodsId.Add(id);
                IFoodRepository foodRepository = new FoodRepository();
                Food food = foodRepository.GetAllAsync().Result.FirstOrDefault(f => f.Id == order.FoodsId[i]);
                order.Money += food.Price;
            }

            IOrderRepository orderRepository = new OrderRepository();

            await orderRepository.CreateAsync(order);
            System.Console.WriteLine("Buyurtma muvaffaqiyatli qabul qilindi.");
            await SubFooter.MakeFooterAsync();


        }
    }
}
