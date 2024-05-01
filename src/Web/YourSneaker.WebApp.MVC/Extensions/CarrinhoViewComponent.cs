using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using YourSneaker.WebApp.MVC.Models;
using YourSneaker.WebApp.MVC.Service;

namespace YourSneaker.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBFFService _carrinhoService;

        public CarrinhoViewComponent(IComprasBFFService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterQuantidadeCarrinho());
        }
    }
}
