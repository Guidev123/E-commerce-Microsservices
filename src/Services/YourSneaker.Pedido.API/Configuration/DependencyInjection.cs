using YourSneaker.Core.Mediator;
using YourSneaker.Pedido.API.Application.Queries;
using YourSneaker.Pedido.Domain.Descontos;
using YourSneaker.Pedido.Domain.Pedidos;
using YourSneaker.Pedido.Infra.Data;
using YourSneaker.Pedido.Infra.Data.Repository;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pedido.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            // APPLICATION
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<ICupomQueries, CupomQueries>();
            // DATA
            services.AddScoped<ICupomRepository, CupomRepository>();
            services.AddScoped<PedidosContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
