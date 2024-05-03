using YourSneaker.Core.Mediator;
using YourSneaker.Pedido.Infra.Data;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pedido.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

        }
    }
}
