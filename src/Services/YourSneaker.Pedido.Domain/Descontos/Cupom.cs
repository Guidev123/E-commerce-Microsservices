using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.DomainObjects;
using YourSneaker.Pedido.Domain.Descontos.Specs;

namespace YourSneaker.Pedido.Domain.Descontos
{
    public class Cupom : Entity, IAggregateRoot
    {
        public string? Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoCupom TipoDesconto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }
        public bool ValidoParaUtilizacao()
        {
            var spec = new CupomAtivoSpecification()
                .And(new CupomQuantidadeSpecification())
                .And(new CupomDataSpecification());

            return spec.IsSatisfiedBy(this);
        }
        public void MarcarComoUtilizado()
        {
            Ativo = false;
            Utilizado = true;
            Quantidade = 0;
        }
    }
}
