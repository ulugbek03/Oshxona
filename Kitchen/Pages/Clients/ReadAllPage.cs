using ConsoleTables;
using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Repositories;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Clients
{
    public sealed class ReadAllPage
    {
        public static async Task RunAsync()
        {
            IClientRepository clientService = new ClientRepository();

            var clients = await clientService.GetAllAsync();

            ConsoleTable table = new ConsoleTable("Id", "Familiya Ismi", "Telefon raqami");

            foreach (var client in clients)
            {
                table.AddRow(client.Id, client.LastName + " " + client.FirstName, client.PhoneNumber);
            }
            table.Write();

            await SubFooter.MakeFooterAsync();
        }
    }
}
