using Microsoft.AspNetCore.Mvc;
using YourSneaker.WebApp.MVC.Service;

namespace YourSneaker.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _catalogoService.ObterTodos();

            return View(produtos);
        }
        [HttpGet]
        [Route("produtos-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id) 
        {
            var produtos = await _catalogoService.ObterPorId(id);
            return View(produtos);
        }
    }
}
