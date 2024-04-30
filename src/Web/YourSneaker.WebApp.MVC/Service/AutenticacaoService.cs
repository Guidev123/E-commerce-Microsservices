using Microsoft.Extensions.Options;
using System.Text.Json;
using YourSneaker.Core.Comunication;
using YourSneaker.WebApp.MVC.Extensions;
using YourSneaker.WebApp.MVC.Models;
using static YourSneaker.WebApp.MVC.Models.UsuarioViewModel;

namespace YourSneaker.WebApp.MVC.Service
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public AutenticacaoService(HttpClient httpClient,
                                    IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                var ss = await response.Content.ReadAsStringAsync();

                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)

                };
            }
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
