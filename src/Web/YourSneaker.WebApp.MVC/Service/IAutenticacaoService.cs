using YourSneaker.WebApp.MVC.Models;
using static YourSneaker.WebApp.MVC.Models.UsuarioViewModel;

namespace YourSneaker.WebApp.MVC.Service
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
