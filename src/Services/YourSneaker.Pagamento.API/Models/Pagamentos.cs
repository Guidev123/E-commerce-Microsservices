using YourSneaker.Core.DomainObjects;

namespace YourSneaker.Pagamento.API.Models
{
    public class Pagamentos : Entity, IAggregateRoot
    {
        public Pagamentos()
        {
            Transacoes = new List<Transacao>();
        }

        public Guid PedidoId { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public decimal Valor { get; set; }

        public CartaoCredito CartaoCredito { get; set; }

        // EF relacionamento
        public ICollection<Transacao> Transacoes { get; set; }

        public void AdicionarTransacao(Transacao transacao)
        {
            Transacoes.Add(transacao);
        }
    }
}
