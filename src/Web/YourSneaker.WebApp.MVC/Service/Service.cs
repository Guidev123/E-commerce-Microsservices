using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using YourSneaker.Core.Comunication;
using YourSneaker.WebApp.MVC.Extensions;
using YourSneaker.WebApp.MVC.Models;

namespace YourSneaker.WebApp.MVC.Service
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var ss = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(ss, options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpExceptionRequest(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected ResponseResult RetornaOk()
        {
            return new ResponseResult();
        }
    }
}
