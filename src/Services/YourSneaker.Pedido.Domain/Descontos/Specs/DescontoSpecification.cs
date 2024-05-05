using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Specification;

namespace YourSneaker.Pedido.Domain.Descontos.Specs
{
    public class CumpomDataSpecification : Specification<Cumpom>
    {
        public override Expression<Func<Cumpom, bool>> ToExpression()
        {
            return desconto => desconto.DataValidade >= DateTime.Now;
        } 
    }

    public class CumpomQuantidadeSpecification : Specification<Cumpom>
    {
        public override Expression<Func<Cumpom, bool>> ToExpression()
        {
            return desconto => desconto.Quantidade > 0;
        }
    }

    public class CumpomAtivoSpecification : Specification<Cumpom> 
    {
        public override Expression<Func<Cumpom, bool>> ToExpression()
        {
            return desconto => desconto.Ativo && !desconto.Utilizado;
        }
    }
}
