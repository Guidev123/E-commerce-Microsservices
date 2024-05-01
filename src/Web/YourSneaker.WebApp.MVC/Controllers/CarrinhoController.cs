using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourSneaker.WebApp.MVC.Models;
using YourSneaker.WebApp.MVC.Service;

namespace YourSneaker.WebApp.MVC.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IComprasBFFService _comprasBFFService;

        public CarrinhoController(IComprasBFFService carrinhoService)
        {
            _comprasBFFService = carrinhoService;
        }

        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _comprasBFFService.ObterCarrinho());
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemProduto)
        {
            var resposta = await _comprasBFFService.AdicionarItemCarrinho(itemProduto);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBFFService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var item = new ItemCarrinhoViewModel { ProdutoId = produtoId, Quantidade = quantidade };
            var resposta = await _comprasBFFService.AtualizarItemCarrinho(produtoId, item);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBFFService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var resposta = await _comprasBFFService.RemoverItemCarrinho(produtoId);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBFFService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }
    }
}
