using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Data;
using YourSneaker.Pedido.Domain.Descontos;

namespace YourSneaker.Pedido.Infra.Data.Repository
{
    public class CupomRepository : ICupomRepository
    {
        private readonly PedidosContext _context;

        public CupomRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Cupom> ObterCupomPorCodigo(string codigo)
        {
            var ret = await _context.Descontos.FirstOrDefaultAsync(p => p.Codigo == codigo);
            return ret;
        }

        public void Atualizar(Cupom cupom)
        {
            //ATUALIZA INFO DO CUPOM NA TABELA DESCONTOS
            _context.Descontos.Update(cupom);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
