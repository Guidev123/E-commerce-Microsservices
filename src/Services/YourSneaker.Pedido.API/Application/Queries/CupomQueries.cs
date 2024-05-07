using YourSneaker.Pedido.API.Application.DTO;
using YourSneaker.Pedido.Domain.Descontos;

namespace YourSneaker.Pedido.API.Application.Queries
{
    public interface ICupomQueries
    {
        Task<CupomDTO> ObterCupomPorCodigo(string codigo);
    }

    public class CupomQueries : ICupomQueries
    {
        private readonly ICupomRepository _cupomRepository;

        public CupomQueries(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }

        public async Task<CupomDTO> ObterCupomPorCodigo(string codigo)
        {
            var cupom = await _cupomRepository.ObterCupomPorCodigo(codigo);

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
