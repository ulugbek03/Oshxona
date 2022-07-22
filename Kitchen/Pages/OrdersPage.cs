using Oshxona.Data.Pages.Orders;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages
{
    public class OrdersPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            var choose = Prompt.Select("Select your city",
                new[] { "1. Buyurtmalar ro'yxati", "2. Buyurtma ma'lumotlari",
                    "3. Buyurtma ma'lumotlarini yangilash", "4. Buyurtma qo'shish","5. Buyurtmani o'chirish" });

            var selectedItem = choose[0];

            if (selectedItem == '1') await ReadAllPage.RunAsync();
            else if (selectedItem == '2') await ReadPage.RunAsync();
            else if (selectedItem == '3') await UpdatePage.RunAsync();
            else if (selectedItem == '4') await CreatePage.RunAsync();
            else if (selectedItem == '5') await DeletePage.RunAsync();
        }
    }
}
