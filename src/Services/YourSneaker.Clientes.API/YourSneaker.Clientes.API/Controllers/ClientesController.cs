using Microsoft.AspNetCore.Mvc;
using YourSneaker.Clientes.API.Aplication.Commands;
using YourSneaker.Core.Mediator;
using YourSneaker.WebAPI.Core.Controllers;

namespace YourSneaker.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
           var resultado = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Gui", "guirafaerln2@gmail.com", "42338435869"));

            return CustomResponse(resultado);
        }
    }
}
