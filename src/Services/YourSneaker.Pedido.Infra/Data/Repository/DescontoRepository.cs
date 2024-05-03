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
    public class DescontoRepository : IDescontoRepository
    {
        private readonly PedidosContext _context;

        public DescontoRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Desconto> ObterDescontoPorCodigo(string codigo)
        {
            return await _context.Descontos.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
