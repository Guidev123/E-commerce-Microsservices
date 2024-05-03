using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Data;

namespace YourSneaker.Pedido.Domain.Descontos
{
    public interface IDescontoRepository : IRepository<Desconto>
    {
        Task<Desconto> ObterDescontoPorCodigo(string codigo);
    }
}
