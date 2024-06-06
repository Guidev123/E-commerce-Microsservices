using YourSneaker.Pagamento.API.Data;
using YourSneaker.Pagamento.API.Data.Repository;
using YourSneaker.Pagamento.API.Facade;
using YourSneaker.Pagamento.API.Models;
using YourSneaker.Pagamento.API.Services;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pagamento.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            // PAGAMENTO
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            // CONTEXT
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}
