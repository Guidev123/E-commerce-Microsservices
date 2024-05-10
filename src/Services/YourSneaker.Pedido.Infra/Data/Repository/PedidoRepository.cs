using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Data;
using YourSneaker.Pedido.Domain.Pedidos;

namespace YourSneaker.Pedido.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;
        public PedidoRepository(PedidosContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        //PEGANDO A CONEXAO DO BANCO DO EF
        public DbConnection ObterConexao() => _context.Database.GetDbConnection();
        public async Task<Pedidos> ObterPorId(Guid id)
        {
            return await _context.Pedidos.FindAsync(id);
        }
        public async Task<IEnumerable<Pedidos>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.PedidoItems)
                .AsNoTracking()
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }
        public void Adicionar(Pedidos pedido)
        {
            _context.Pedidos.Add(pedido);
        }
        public void Atualizar(Pedidos pedido)
        {
            _context.Pedidos.Update(pedido);
        }
        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
            return await _context.PedidoItems.FindAsync(id);
        }
        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            var ret = await _context.PedidoItems
                .FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);
            return ret;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
