using System;
using System.Security.Cryptography;
using System.Text;

namespace Oshxona.Service
{
    public class LogPass
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public static class Heshlash
    {
        //public static void Run()
        //{
        //    LogPass logPass = new LogPass();
        //    logPass.Login = GetHashVersion("admin");
        //    logPass.Password = GetHashVersion("admin");
        //    var json = JsonConvert.SerializeObject(logPass);
        //    File.WriteAllText(DbConstants.HESHLAR_DB_PATH, json);

        //}
        public static string GetHashVersion(this string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
