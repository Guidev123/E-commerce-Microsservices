using YourSneaker.Pagamento.API.Data;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pagamento.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<PagamentosContext>();
        }
    }
}
