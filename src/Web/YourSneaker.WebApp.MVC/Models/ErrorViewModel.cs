using System.Text.Json.Serialization;
using YourSneaker.WebApp.MVC.Extensions;

namespace YourSneaker.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
    }

}
