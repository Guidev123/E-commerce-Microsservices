using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.DomainObjects;
using YourSneaker.Pedido.Domain.Descontos;

namespace YourSneaker.Pedido.Domain.Pedidos
{
    public class Pedidos : Entity, IAggregateRoot
    {
        public Pedidos(Guid clienteId, decimal valorTotal, List<PedidoItem> pedidoItems, bool cupomUtilizado = false, decimal desconto = 0,
            Guid? cupomId = null)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            _pedidoItems = pedidoItems;
            Desconto = desconto;
            CupomUtilizado = cupomUtilizado;
            CupomId = cupomId;
        }

        //EF ctor
        public Pedidos() { }
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? CupomId { get; private set; }
        public bool CupomUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        public Endereco Endereco { get; private set; }

        //EF rel
        public Cupom Cupom { get; private set; }

        public void AutorizarPedido()
        {
            PedidoStatus = PedidoStatus.Autorizado;
        }
        public void AtribuirCupom(Cupom cupom)
        {
            CupomUtilizado = true;
            CupomId = cupom.Id;
            Cupom = cupom;
        }
        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void CalculoDoValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        private void CalcularValorTotalDesconto()
        {
            if (!CupomUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Cupom.TipoDesconto == TipoDesconto.Porcentagem)
            {
                if (Cupom.Percentual.HasValue)
                {
                    desconto = (valor * Cupom.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Cupom.ValorDesconto.HasValue)
                {
                    desconto = Cupom.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }
    }
}
