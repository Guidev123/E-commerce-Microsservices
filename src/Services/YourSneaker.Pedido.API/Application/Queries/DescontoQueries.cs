using YourSneaker.Pedido.API.Application.DTO;
using YourSneaker.Pedido.Domain.Descontos;

namespace YourSneaker.Pedido.API.Application.Queries
{
    public interface ICumpomQueries
    {
        Task<CupomDTO> ObterCumpomPorCodigo(string codigo);
    }

    public class DescontoQueries : ICumpomQueries
    {
        private readonly ICupomRepository _cumpomRepository;

        public DescontoQueries(ICupomRepository cumpomRepository)
        {
            _cumpomRepository = cumpomRepository;
        }

        public async Task<CupomDTO> ObterCumpomPorCodigo(string codigo)
        {
            var cupom = await _cumpomRepository.ObterCumpomPorCodigo(codigo);

            if (cupom == null) return null;

            if (!cupom.ValidoParaUtilizacao()) return null;

            return new CupomDTO
            {
                Codigo = cupom.Codigo,
                TipoDesconto = (int)cupom.TipoDesconto,
                Percentual = cupom.Percentual,
                ValorDesconto = cupom.ValorDesconto
            };
        }
    }
}
