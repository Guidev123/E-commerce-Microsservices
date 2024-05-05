using Microsoft.Extensions.Options;
using YourSneaker.Core.Comunication;
using YourSneaker.WebApp.MVC.Extensions;
using YourSneaker.WebApp.MVC.Models;

namespace YourSneaker.WebApp.MVC.Service
{
    public interface IComprasBFFService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<int> ObterQuantidadeCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarCupomCarrinho(string cupom);
    }
    public class ComprasBFFService : Service, IComprasBFFService
    {
        private readonly HttpClient _httpClient;

        public ComprasBFFService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ComprasBFFUrl);
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
        }
        public async Task<int> ObterQuantidadeCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho-quantidade/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }
        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel carrinho)
        {
            var itemContent = ObterConteudo(carrinho);

            var response = await _httpClient.PostAsync("/compras/carrinho/items/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornaOk();
        }
        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel item)
        {
            var itemContent = ObterConteudo(item);

            var response = await _httpClient.PutAsync($"/compras/carrinho/items/{produtoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornaOk();
        }
        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/compras/carrinho/items/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornaOk();
        }

        public async Task<ResponseResult> AplicarCupomCarrinho(string cupom)
        {
            var itemContent = ObterConteudo(cupom);

            var response = await _httpClient.PostAsync("/compras/carrinho/aplicar-cupom/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornaOk();
        }
    }
}
