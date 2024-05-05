using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Data;

namespace YourSneaker.Pedido.Domain.Descontos
{
    public interface ICupomRepository : IRepository<Cumpom>
    {
        Task<Cumpom> ObterCumpomPorCodigo(string codigo);
    }
}
