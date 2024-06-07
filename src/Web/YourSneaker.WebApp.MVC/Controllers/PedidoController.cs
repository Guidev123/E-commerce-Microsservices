using Microsoft.AspNetCore.Mvc;
using YourSneaker.WebApp.MVC.Models;
using YourSneaker.WebApp.MVC.Service;

namespace YourSneaker.WebApp.MVC.Controllers
{
    public class PedidoController : MainController
    {
        private readonly IClienteService _clienteService;
        private readonly IComprasBFFService _comprasBFFService;

        public PedidoController(IClienteService clienteService,
            IComprasBFFService comprasBFFService)
        {
            _clienteService = clienteService;
            _comprasBFFService = comprasBFFService;
        }

        [HttpGet]
        [Route("endereco-de-entrega")]
        public async Task<IActionResult> EnderecoEntrega()
        {
            var carrinho = await _comprasBFFService.ObterCarrinho();
            if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

            var endereco = await _clienteService.ObterEndereco();
            var pedido = _comprasBFFService.MapearParaPedido(carrinho, endereco);

            return View(pedido);
        }

        [HttpGet]
        [Route("pagamento")]
        public async Task<IActionResult> Pagamento()
        {
            var carrinho = await _comprasBFFService.ObterCarrinho();
            if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

            var endereco = await _clienteService.ObterEndereco(); //BUSCANDO ENDERECO

            var pedido = _comprasBFFService.MapearParaPedido(carrinho, endereco);

            return View(pedido);
        }
       
        [HttpPost]
        [Route("finalizar-pedido")]
        public async Task<IActionResult> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao)
        {
            if (!ModelState.IsValid) return View("Pagamento", _comprasBFFService.MapearParaPedido(
                await _comprasBFFService.ObterCarrinho(), null));

            //BUSCANDO ENDERECO
            var endereco = await _clienteService.ObterEndereco();
            pedidoTransacao.Endereco = endereco;

            //OBTEM CARRINHO
            var carrinho = await _comprasBFFService.ObterCarrinho();
            pedidoTransacao.PedidoItems = carrinho.Itens;
            pedidoTransacao.ValorTotal = carrinho.ValorTotal;
            pedidoTransacao.CumpomUtilizado = carrinho.CumpomUtilizado;
            pedidoTransacao.Desconto = carrinho.Desconto;

            var retorno = await _comprasBFFService.FinalizarPedido(pedidoTransacao);

            if (ResponsePossuiErros(retorno))
            {
                var carrinhoVerificaQuantidade = await _comprasBFFService.ObterCarrinho();
                if (carrinhoVerificaQuantidade.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

                
                var pedidoMap = _comprasBFFService.MapearParaPedido(carrinhoVerificaQuantidade, endereco);
                return View("Pagamento", pedidoMap);
            }

            return RedirectToAction("PedidoConcluido");
        }

        [HttpGet]
        [Route("pedido-concluido")]
        public async Task<IActionResult> PedidoConcluido()
        {
            return View("ConfirmacaoPedido", await _comprasBFFService.ObterUltimoPedido());
        }

        [HttpGet("meus-pedidos")]
        public async Task<IActionResult> MeusPedidos()
        {
            return View(await _comprasBFFService.ObterListaPorClienteId());
        }
    }
}
