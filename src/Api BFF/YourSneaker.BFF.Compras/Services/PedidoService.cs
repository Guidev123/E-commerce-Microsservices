using Microsoft.Extensions.Options;
using System.Net;
using YourSneaker.BFF.Compras.Extensions;
using YourSneaker.BFF.Compras.Models;

namespace YourSneaker.BFF.Compras.Services
{
    public interface IPedidoService
    {
        Task<CupomDTO> ObterCupomPorCodigo(string codigo);
    }

    public class PedidoService : Service, IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
        }

        public async Task<CupomDTO> ObterCupomPorCodigo(string codigo)
        {
            var response = await _httpClient.GetAsync($"/cupom/{codigo}/");

            if(response.StatusCode == HttpStatusCode.NotFound) return null;
            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CupomDTO>(response);
        }
    }
}
