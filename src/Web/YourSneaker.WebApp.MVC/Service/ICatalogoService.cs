using Refit;
using YourSneaker.WebApp.MVC.Models;

namespace YourSneaker.WebApp.MVC.Service
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
