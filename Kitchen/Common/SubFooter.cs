using Oshxona.Data.Pages;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace Oshxona.Service.Common
{
    public class SubFooter
    {
        public static async Task MakeFooterAsync()
        {
            var choose = Prompt.Select("Tanlang", new[] {
                    "1. Menu",
                    "2. Exit" });

            var selectedItem = choose[0];

            if (selectedItem == '1') await MainMenuPage.RunAsync();
            else if (selectedItem == '2') Environment.Exit(0);

        }
    }
}
