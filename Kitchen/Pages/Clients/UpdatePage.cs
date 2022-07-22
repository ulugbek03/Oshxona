using Oshxona.Data.Common;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Oshxona.Data.Repositories;
using Sharprompt;
using System.Threading.Tasks;

namespace Oshxona.Service.Clients
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            int id = Prompt.Input<int>("ID kiriting");
            var FirstName = Prompt.Input<string>("Ismingizni kiriting");
            var LastName = Prompt.Input<string>("Familiyangizni kiriting ");
            var PhoneNumber = Prompt.Input<string>("Telefon raqamingizni kiriting");

            Client client = new Client()
            {
                Id = id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber

            };


            IClientRepository clientRepository = new ClientRepository();

            await clientRepository.UpdateAsync(id, client);
            System.Console.WriteLine("Akkount muvaffaqiyatli yangilandi.");
            await SubFooter.MakeFooterAsync();

        }
    }
}
