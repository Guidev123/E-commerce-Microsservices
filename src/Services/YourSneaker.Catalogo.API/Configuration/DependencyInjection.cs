using YourSneaker.Catalogo.API.Data.Repository;
using YourSneaker.Catalogo.API.Data;
using YourSneaker.Catalogo.API.Models;

namespace YourSneaker.Catalogo.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
