using FluentValidation.Results;
using MediatR;
using YourSneaker.Core.Messages;
using YourSneaker.Pedido.API.Application.DTO;
using YourSneaker.Pedido.API.Application.Events;
using YourSneaker.Pedido.Domain.Descontos;
using YourSneaker.Pedido.Domain.Descontos.Specs;
using YourSneaker.Pedido.Domain.Pedidos;

namespace YourSneaker.Pedido.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler,
          IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICupomRepository _cupomRepository;

        public PedidoCommandHandler(ICupomRepository cupomRepository,
                                    IPedidoRepository pedidoRepository)
        {
            _cupomRepository = cupomRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
        {
            // VALIDAR COMANDO
            if (!message.EstaValido()) return message.ValidationResult;

            // MAPEAR PEDIDO
            var pedido = MapearPedido(message);

            // APLICAR CUPOM SE HOUVER
            if (!await AplicarCupom(message, pedido)) return ValidationResult;

            // VALIDAR PEDIDO
            if (!ValidarPedido(pedido)) return ValidationResult;

            // PROCESSA PAGAMENTO
            if (!ProcessarPagamento(pedido)) return ValidationResult;

            // CASO O PAGAMENTO ESTEJA OK!
            pedido.AutorizarPedido();

            // ADICIONAR EVENTO
            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            // ADICIONAR PEDIDO REPOSITORY
            _pedidoRepository.Adicionar(pedido);

            // PERSISTIR DADOS DE PEDIDO E CUPOM ATRAVES DO UNITOFWORK
            return await PersistirDado(_pedidoRepository.UnitOfWork);
        }

        private Pedidos MapearPedido(AdicionarPedidoCommand message)
        {
            var endereco = new Endereco
            {
                Logradouro = message.Endereco.Logradouro,
                Numero = message.Endereco.Numero,
                Complemento = message.Endereco.Complemento,
                Bairro = message.Endereco.Bairro,
                Cep = message.Endereco.Cep,
                Cidade = message.Endereco.Cidade,
                Estado = message.Endereco.Estado
            };

            var pedido = new Pedidos(message.ClienteId, message.ValorTotal, message.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
                message.CupomUtilizado, message.Desconto);

            pedido.AtribuirEndereco(endereco);
            return pedido;
        }

        private async Task<bool> AplicarCupom(AdicionarPedidoCommand message, Pedidos pedido)
        {
            if (!message.CupomUtilizado) return true;

            var cupom = await _cupomRepository.ObterCupomPorCodigo(message.CupomCodigo);
            if (cupom == null)
            {
                AdicionarErro("O cupom informado não existe!");
                return false;
            }

            var cupomValidation = new CupomValidation().Validate(cupom);
            if (!cupomValidation.IsValid)
            {
                cupomValidation.Errors.ToList().ForEach(m => AdicionarErro(m.ErrorMessage));
                return false;
            }

            pedido.AtribuirCupom(cupom);
            cupom.DebitarQuantidade();

            _cupomRepository.Atualizar(cupom);

            return true;
        }

        private bool ValidarPedido(Pedidos pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Cupom;

            pedido.CalculoDoValorPedido();

            if (pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if (pedido.Cupom != pedidoDesconto)
            {
                AdicionarErro("O valor total não confere com o cálculo do pedido");
                return false;
            }

            return true;
        }

        public bool ProcessarPagamento(Pedidos pedido)
        {
            return true;
        }
    }
}
