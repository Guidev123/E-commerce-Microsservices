using Microsoft.EntityFrameworkCore;
using YourSneaker.Core.Data;
using YourSneaker.Pagamento.API.Models;

namespace YourSneaker.Pagamento.API.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentosContext _context;

        public PagamentoRepository(PagamentosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarPagamento(Pagamentos pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }
        public void Dispose()
        {
            _context?.Dispose(); 
        }
    }
}
