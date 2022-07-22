using Oshxona.Data.Pages.Foods;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Service.Pages
{
    public class FoodsPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            var choose = Prompt.Select("",
                new[] { "1. Ovqatlar ro'yxati", "2. Ovqat ma'lumotlari",
                    "3. Ovqat ma'lumotlarini yangilash", "4. Ovqat qo'shish","5. Ovqatni o'chirish" });

            var selectedItem = choose[0];

            if (selectedItem == '1') await ReadAllPage.RunAsync();
            else if (selectedItem == '2') await ReadPage.RunAsync();
            else if (selectedItem == '3') await UpdatePage.RunAsync();
            else if (selectedItem == '4') await CreatePage.RunAsync();
            else if (selectedItem == '5') await DeletePage.RunAsync();
        }
    }
}
