using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Data;

namespace YourSneaker.Pedido.Domain.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedidos>
    {
        Task<Pedidos> ObterPorId(Guid id);
        Task<IEnumerable<Pedidos>> ObterListaPorClienteId(Guid clienteId);
        void Adicionar(Pedidos pedido);
        void Atualizar(Pedidos pedido);  

        // Pedido Item 
        Task<PedidoItem> ObterItemPorId(Guid id);   
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
    }
}
