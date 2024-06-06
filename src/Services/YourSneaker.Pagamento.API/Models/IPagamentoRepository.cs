 using YourSneaker.Core.Data;

namespace YourSneaker.Pagamento.API.Models
{
    public interface IPagamentoRepository : IRepository<Pagamentos>
    {
        void AdicionarPagamento(Pagamentos pagamento);
        void AdicionarTransacao(Transacao transacao);
        Task<Pagamentos> ObterPagamentoPorPedidoId(Guid pedidoId);
        Task<IEnumerable<Transacao>> ObterTransacaoesPorPedidoId(Guid pedidoId);
    }
}
