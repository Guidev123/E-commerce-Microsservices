using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourSneaker.WebApp.MVC.Models;

namespace YourSneaker.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("sistema-fora-do-ar")]
        public IActionResult SistemaForaDoAr()
        {
            var modelErro = new ErrorViewModel
            {
                Mensagem = "O sistema está temporariamente fora do ar, pode ocorrer pelo excesso de requisições de usuarios.",
                Titulo = "Sistema Fora do ar.",
                ErroCode = 500,
            };
            return View("Error", modelErro);
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem =
                    "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
