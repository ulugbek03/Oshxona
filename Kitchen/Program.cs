using Oshxona.Service.Common;
using Oshxona.Data;
using Oshxona.Data.Pages;
using Newtonsoft.Json;
using Sharprompt;
using System;
using System.IO;
using System.Threading.Tasks;
using Oshxona.Service;

namespace Oshxona.Data
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
        
            
            //Login Parol: admin admin
        Start:

            string login = Prompt.Input<string>("Login");
            string password = Prompt.Password("Password");
            var json = await File.ReadAllTextAsync(DbConstants.HESHLAR_DB_PATH);
            LogPass logPass = JsonConvert.DeserializeObject<LogPass>(json);
            if (logPass.Login == Heshlash.GetHashVersion(login) && logPass.Password == Heshlash.GetHashVersion(password))
            {
                try
                {
                    await MainMenuPage.RunAsync();

                }
                catch (Exception)
                {
                    await SubFooter.MakeFooterAsync();
                }
            }
            else
            {
                Console.WriteLine("Login yoki parol noto'g'ri, qaytadan kiriting.");
                goto Start;
            }
        }

    }
}
