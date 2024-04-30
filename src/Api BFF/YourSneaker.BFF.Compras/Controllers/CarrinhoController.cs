using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourSneaker.BFF.Compras.Models;
using YourSneaker.BFF.Compras.Services;
using YourSneaker.WebAPI.Core.Controllers;

namespace YourSneaker.BFF.Compras.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        public readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;

        public CarrinhoController(ICarrinhoService carrinhoService, ICatalogoService catalogoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
        }


        [HttpGet]
        [Route("compras/carrinho")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse(await _carrinhoService.ObterCarrinho());
        }

        [HttpGet]
        [Route("compras/carrinho-quantidade")]
        public async Task<int> ObterQuantidadeCarrinho()
        {
            var quantidade = await _carrinhoService.ObterCarrinho();
            return quantidade?.Itens.Sum(i => i.Quantidade) ?? 0;
        }

        [HttpPost]
        [Route("compras/carrinho/items")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoDTO itemProduto)
        {
            var produto = await _catalogoService.ObterProdutoPorId(itemProduto.ProdutoId);

            await ValidarItensDoCarrinho(produto, itemProduto.Quantidade);
            if (!ValidOperation()) return CustomResponse();

            itemProduto.Nome = produto.Nome;
            itemProduto.Valor = produto.Valor;
            itemProduto.Imagem = produto.Imagem;

            var resposta = await _carrinhoService.AdicionarItemCarrinho(itemProduto);

            return CustomResponse(resposta);
        }

        [HttpPut]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO itemProduto)
        {
            var produto = await _catalogoService.ObterProdutoPorId(produtoId);

            await ValidarItensDoCarrinho(produto, itemProduto.Quantidade);
            if(!ValidOperation()) return CustomResponse();

            var resposta = await _carrinhoService.AtualizarItemCarrinho(produtoId, itemProduto);

            return CustomResponse(resposta);
        }

        [HttpDelete]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var produto = await _catalogoService.ObterProdutoPorId(produtoId);

            if (produto == null) { 
                AddProcessError("Produto não existe");
                return CustomResponse();
            }

            var resposta = await _carrinhoService.RemoverItemCarrinho(produtoId);
            return CustomResponse(resposta);    
        }

        private async Task ValidarItensDoCarrinho(ItemProdutoDTO produto, int quantiade)
        {
            if (produto == null) AddProcessError("O produto não existe");
            if (quantiade < 1) AddProcessError($"Adicione ao menos uma unidade de {produto.Nome}");

            var carrinho = await _carrinhoService.ObterCarrinho();
            var itemCarrinho = carrinho.Itens.FirstOrDefault(p => p.ProdutoId == produto.Id);

            if(itemCarrinho != null && itemCarrinho.Quantidade + quantiade > produto.QuantidadeEstoque)
            {
                AddProcessError($"{produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque, você tentou comprar {quantiade} unidades");
                return;
            }

            if (quantiade > produto.QuantidadeEstoque) AddProcessError($"{produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque, você tentou comprar {quantiade} unidades");
        }
    }
}
