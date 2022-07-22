using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Data.Pages.Orders
{
    internal class DeletePage
    {
        public static async Task RunAsync()
        {
            try
            {

                int id = Prompt.Input<int>("ID kiriting");
                IOrderRepository orderRepository = new OrderRepository();
                await orderRepository.DeleteAsync(id);
                System.Console.WriteLine("Ushbu mijoz o'chirildi.");
                await SubFooter.MakeFooterAsync();

            }
            catch (System.Exception)
            {

            }
        }
    }
}
