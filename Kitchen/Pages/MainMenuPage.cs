using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages
{
    public class MainMenuPage
    {
        public static async Task RunAsync()
        {


            Console.Clear();
            var choose = Prompt.Select("Assalomu alaykum dasturimizga xush kelibsiz!",
                new[] { "1. Ovqatlar ro'yxati", "2. Mijozlar ro'yxati", "3. Buyurtmalar ro'yxati" });

            var selectedItem = choose[0];

            if (selectedItem == '1') await FoodsPage.RunAsync();
            else if (selectedItem == '2') await ClientsPage.RunAsync();
            else if (selectedItem == '3') await OrdersPage.RunAsync();


        }

    }
}
