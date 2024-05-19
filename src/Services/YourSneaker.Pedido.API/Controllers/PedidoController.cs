using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourSneaker.Core.Mediator;
using YourSneaker.Pedido.API.Application.Commands;
using YourSneaker.Pedido.API.Application.DTO;
using YourSneaker.Pedido.API.Application.Queries;
using YourSneaker.WebAPI.Core.Controllers;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pedido.API.Controllers
{
    [Authorize]
    public class PedidoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IMediatorHandler mediator,
            IAspNetUser user,
            IPedidoQueries pedidoQueries)
        {
            _mediator = mediator;
            _user = user;
            _pedidoQueries = pedidoQueries;
        }

        //[HttpPost("pedido")]
        //public async Task<IActionResult> AdicionarPedido(AdicionarPedidoCommand pedido)
        //{
        //    pedido.ClienteId = _user.ObterUserId();
        //    return CustomResponse(await _mediator.EnviarComando(pedido));
        //}


        [HttpPost("pedido")]
        public async Task<IActionResult> AdicionarPedido(PedidoTransacaoDTO pedido)
        {
            AdicionarPedidoCommand pedidoCommand = new AdicionarPedidoCommand
            {
                ClienteId = _user.ObterUserId(),
                ValorTotal = pedido.ValorTotal,
                PedidoItems = pedido.PedidoItems,
                CupomCodigo = pedido.CupomCodigo,
                CupomUtilizado = pedido.CupomUtilizado,
                Desconto = pedido.Desconto,
                Endereco = pedido.Endereco,
                NumeroCartao = pedido.NumeroCartao,
                NomeCartao = pedido.NomeCartao,
                ExpiracaoCartao = pedido.ExpiracaoCartao,
                CvvCartao = pedido.CvvCartao,
            };


            return CustomResponse(await _mediator.EnviarComando(pedidoCommand));
    }


    [HttpGet("pedido/ultimo")]
    public async Task<IActionResult> UltimoPedido()
    {
        var pedido = await _pedidoQueries.ObterUltimoPedido(_user.ObterUserId());

        return pedido == null ? NotFound() : CustomResponse(pedido);
    }

    [HttpGet("pedido/lista-cliente")]
    public async Task<IActionResult> ListaPorCliente()
    {
        var pedidos = await _pedidoQueries.ObterListaPorClienteId(_user.ObterUserId());

        return pedidos == null ? NotFound() : CustomResponse(pedidos);
    }
}
}
