using YourSneaker.Core.Messages.Integration;
using YourSneaker.Pagamento.API.Models;

namespace YourSneaker.Pagamento.API.Services
{
    public interface IPagamentoService
    {
        Task<ResponseMessage> AutorizarPagamento(Pagamentos pagamento);
    }
}
