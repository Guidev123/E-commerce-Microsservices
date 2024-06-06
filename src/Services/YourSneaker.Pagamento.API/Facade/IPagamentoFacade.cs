using YourSneaker.Pagamento.API.Models;

namespace YourSneaker.Pagamento.API.Facade
{
    public interface IPagamentoFacade
    {
        Task<Transacao> AutorizarPagamento(Pagamentos pagamento);
    }
}
