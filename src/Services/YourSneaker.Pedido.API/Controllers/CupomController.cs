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
    public class CupomController : MainController
    {
        private readonly ICupomQueries _cupomQueries;

        public CupomController(ICupomQueries cumpoQueries)
        {
            _cupomQueries = cumpoQueries;
        }

        [HttpGet("cupom/{codigo}")]
        [ProducesResponseType(typeof(CupomDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return NotFound();

            var cupom = await _cupomQueries.ObterCupomPorCodigo(codigo);

            return cupom == null ? NotFound() : CustomResponse(cupom);
        }
    }
}
