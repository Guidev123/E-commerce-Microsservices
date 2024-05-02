using Microsoft.AspNetCore.Mvc;

namespace YourSneaker.Pedido.API.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
