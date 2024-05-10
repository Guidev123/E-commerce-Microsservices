using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Specification;

namespace YourSneaker.Pedido.Domain.Descontos.Specs
{
    public class CupomDataSpecification : Specification<Cupom>
    {
        public override Expression<Func<Cupom, bool>> ToExpression()
        {
            return desconto => desconto.DataValidade >= DateTime.Now;
        } 
    }

    public class CupomQuantidadeSpecification : Specification<Cupom>
    {
        public override Expression<Func<Cupom, bool>> ToExpression()
        {
            return desconto => desconto.Quantidade > 0;
        }
    }

    public class CupomAtivoSpecification : Specification<Cupom> 
    {
        public override Expression<Func<Cupom, bool>> ToExpression()
        {
            return desconto => desconto.Ativo && !desconto.Utilizado;
        }
    }
}
