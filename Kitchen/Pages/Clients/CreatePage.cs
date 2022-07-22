using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages.Clients
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            var FirstName = Prompt.Input<string>("Ismingizni kiriting");
            var LastName = Prompt.Input<string>("Familiyangizni kiriting ");
            var PhoneNumber = Prompt.Input<string>("Telefon raqamingizni kiriting");

            Client client = new Client()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber

            };


            IClientRepository clientRepository = new ClientRepository();

            await clientRepository.CreateAsync(client);
            System.Console.WriteLine("Akkount muvaffaqiyatli yaratildi.");
            await SubFooter.MakeFooterAsync();

        }
    }
}
