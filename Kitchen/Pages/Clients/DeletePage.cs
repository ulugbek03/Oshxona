using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Clients
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            try
            {

                int id = Prompt.Input<int>("ID kiriting");

                IClientRepository clientRepository = new ClientRepository();
                await clientRepository.DeleteAsync(id);

                System.Console.WriteLine("Ushbu buyurtma o'chirildi.");

                await SubFooter.MakeFooterAsync();

            }
            catch (System.Exception)
            {

            }

        }
    }
}
