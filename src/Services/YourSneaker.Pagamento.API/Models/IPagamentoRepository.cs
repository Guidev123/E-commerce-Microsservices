 using YourSneaker.Core.Data;

namespace YourSneaker.Pagamento.API.Models
{
    public interface IPagamentoRepository : IRepository<Pagamentos>
    {
        void AdicionarPagamento(Pagamentos pagamento);
    }
}
