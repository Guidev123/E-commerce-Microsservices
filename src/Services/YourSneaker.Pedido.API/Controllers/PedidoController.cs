using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YourSneaker.Pedido.API.Application.DTO;
using YourSneaker.Pedido.API.Application.Queries;
using YourSneaker.Pedido.Domain.Descontos;
using YourSneaker.WebAPI.Core.Controllers;

namespace YourSneaker.Pedido.API.Controllers
{
    [Authorize]
    public class PedidoController : MainController
    {
        private readonly ICumpomQueries _cumpomQueries;

        public PedidoController(ICumpomQueries cumpoQueries)
        {
            _cumpomQueries = cumpoQueries;
        }

        [HttpGet("cumpom/{codigo}")]
        [ProducesResponseType(typeof(CupomDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return NotFound();

            var cumpom = await _cumpomQueries.ObterCumpomPorCodigo(codigo);

            return cumpom == null ? NotFound() : CustomResponse(codigo);
        }
    }
}
