using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourSneaker.Carrinho.API.Data;
using YourSneaker.Carrinho.API.Models;
using YourSneaker.WebAPI.Core.Controllers;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Carrinho.API.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly CarrinhoContext _context;
        public CarrinhoController(IAspNetUser user, CarrinhoContext context)
        {
            _user = user;
            _context = context;
        }

        [HttpGet("carrinho")]
        public async Task<CarrinhoCliente> ObterCarrinho()
        {
            return await ObterCarrinhoCliente() ?? new CarrinhoCliente();
        }

        [HttpPost("carrinho")]
        public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItem item)
        {
            var carrinho = new CarrinhoCliente();


            if (carrinho == null) ManipularNovoCarrinho(item);
            
            else ManipulaCarrinhoExistente(carrinho, item);

            ValidarCarrinho(carrinho);
            if (!ValidOperation()) return CustomResponse();


            await PersistirDados();
            return CustomResponse();

        }

        [HttpPut("carrinho/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, CarrinhoItem item)
        {
            var carrinho = await ObterCarrinho();
            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho, item);
            if(itemCarrinho == null) return CustomResponse();

            carrinho.AtualizarUnidades(itemCarrinho, item.Quantidade);

            ValidarCarrinho(carrinho);
            if (!ValidOperation()) return CustomResponse();

            _context.CarrinhoItens.Update(itemCarrinho);
            _context.CarrinhoCliente.Update(carrinho);


            await PersistirDados();
            return CustomResponse();

        }

        [HttpDelete("carrinho/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var carrinho = await ObterCarrinhoCliente();
            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho);
            if (itemCarrinho == null) return CustomResponse();

            carrinho.RemoverItem(itemCarrinho);

            ValidarCarrinho(carrinho);
            if (!ValidOperation()) return CustomResponse();

            _context.CarrinhoItens.Remove(itemCarrinho);
            _context.CarrinhoCliente.Update(carrinho);

            await PersistirDados(); 
            return CustomResponse();
        }

        private async Task<CarrinhoCliente> ObterCarrinhoCliente()
        {
            return await _context.CarrinhoCliente
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.ClienteId == _user.ObterUserId());
        }

        private void ManipularNovoCarrinho(CarrinhoItem item) 
        {
            var carrinho = new CarrinhoCliente(_user.ObterUserId());
            carrinho.AdicionarItem(item);

            _context.CarrinhoCliente.Add(carrinho);
        }

        private void ManipulaCarrinhoExistente(CarrinhoCliente carrinho, CarrinhoItem item)
        {
            var produtoItemExistente = carrinho.CarrinhoItemExiste(item);

            carrinho.AdicionarItem(item);

            if (produtoItemExistente) _context.CarrinhoItens.Update(carrinho.ObterProdutoPorId(item.ProdutoId));

            else _context.CarrinhoItens.Add(item);

            _context.CarrinhoCliente.Update(carrinho);
        }

        private async Task<CarrinhoItem> ObterItemCarrinhoValidado(Guid produtoId, CarrinhoCliente carrinho, CarrinhoItem item = null)
        {
            if(item != null && produtoId != item.ProdutoId)
            {
                AddProcessError("O item não corresponde ao item informado");
                return null;
            }
            else if(carrinho == null)
            {
                AddProcessError("Carrinho não existe");
                return null;
            }

            var itemCarrinho = await _context.CarrinhoItens.FirstOrDefaultAsync(i => i.CarrinhoId == carrinho.Id && i.ProdutoId == produtoId);

            if(itemCarrinho == null || !carrinho.CarrinhoItemExiste(itemCarrinho))
            {
                AddProcessError("O item não existe no carrinho");
                return null;
            }

            return itemCarrinho;
        }
        
        private async Task PersistirDados()
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0) AddProcessError("Não foi possivel persistir os dados no banco de dados");
        }

        internal bool ValidarCarrinho(CarrinhoCliente carrinho)
        {
            if (carrinho.EhValido()) return true;

            carrinho.ValidationResult.Errors.ToList().ForEach(error => AddProcessError(error.ErrorMessage));
            return false;
        }
    }
}
