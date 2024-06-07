using Microsoft.AspNetCore.Mvc;
using YourSneaker.Clientes.API.Aplication.Commands;
using YourSneaker.Clientes.API.Models;
using YourSneaker.Core.Mediator;
using YourSneaker.WebAPI.Core.Controllers;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClientesController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        //[HttpPost("cliente/endereco")]
        //public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        //{
        //    endereco.ClienteId = _user.ObterUserId();
        //    return CustomResponse(await _mediator.EnviarComando(endereco));
        //}
        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(EnderecoDTO endereco)
        {
            var enderecoCommand = new AdicionarEnderecoCommand
            {
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                ClienteId = _user.ObterUserId()
            };
            return CustomResponse(await _mediator.EnviarComando(enderecoCommand));
        }
    }
}
