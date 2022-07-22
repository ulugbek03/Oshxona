using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Linq;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Orders
{
    internal class UpdatePage
    {
        public static async Task RunAsync()
        {
            int id = Prompt.Input<int>("Buyurtma IDisini kiriting");
            Order order = new Order();
            order.OrderDate = System.DateTime.Now;
            int ClId = Prompt.Input<int>("Mijoz IDisini kiriting");

            order.ClientId = ClId;

            int n = Prompt.Input<int>("Nechta taom sotib olasiz");

            order.Money = 0;
            for (int i = 0; i < n; i++)
            {

                int FoodId = Prompt.Input<int>($"{i + 1}-Taom IDisini kiriting");
                order.FoodsId.Add(FoodId);
                IFoodRepository foodRepository = new FoodRepository();
                Food food = foodRepository.GetAllAsync().Result.FirstOrDefault(f => f.Id == order.FoodsId[i]);
                order.Money += food.Price;
            }
            order.Id = id;
            IOrderRepository orderRepository = new OrderRepository();
            await orderRepository.UpdateAsync(id, order);

            System.Console.WriteLine("Buyurtma muvaffaqiyatli yangilandi.");
            await SubFooter.MakeFooterAsync();


        }
    }
}
