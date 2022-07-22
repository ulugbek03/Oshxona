using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Clients
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            int id = Prompt.Input<int>("ID kiriting");

            IClientRepository clientRepository = new ClientRepository();
            var client = await clientRepository.GetAsync(id);


            ConsoleTable table = new ConsoleTable("Id", "Familiya Ismi", "Telefon raqami");
            table.AddRow(client.Id, client.LastName + " " + client.FirstName, client.PhoneNumber);

            table.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
