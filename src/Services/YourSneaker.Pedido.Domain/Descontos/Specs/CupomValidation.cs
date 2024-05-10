using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Specification.Validation;

namespace YourSneaker.Pedido.Domain.Descontos.Specs
{
    public class CupomValidation : SpecValidator<Cupom>
    {
        public CupomValidation()
        {
            var dataSpec = new CupomDataSpecification();
            var qntSpec = new CupomQuantidadeSpecification();
            var ativoSpec = new CupomAtivoSpecification();

            Add("dataSpec", new Rule<Cupom>(dataSpec, "Este cupom está expirado"));
            Add("qntSpec", new Rule<Cupom>(qntSpec, "Este cupom já foi utilizado"));
            Add("ativoSpec", new Rule<Cupom>(ativoSpec, "Este cupom não está ativo"));
                
        }
    }
}
