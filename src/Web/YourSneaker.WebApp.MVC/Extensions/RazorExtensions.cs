using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;

namespace YourSneaker.WebApp.MVC.Extensions
{
    public static class RazorExtensions
    {

        //Take the email profile image
        public static string HashEmailGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();
            foreach (var T in data)
            {
                sBuilder.Append(T.ToString("x2"));
            }

            return sBuilder.ToString();
        }


        public static string MoneyFormat(this RazorPage page, decimal valor)
        {
            return valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        }

        public static string StockMessage(this RazorPage page, int quantidade)
        {
            return quantidade > 0 ? $"Apenas {quantidade} unidades disponíveis" : "Esgotado!";
        }
    }
}
