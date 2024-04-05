using YourSneaker.WebApp.MVC.Extensions;
using YourSneaker.WebApp.MVC.Service;
using YourSneaker.WebApp.MVC.Service.handlers;

namespace YourSneaker.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services) 
        {
            services.AddTransient<HttpClientAuthDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthDelegatingHandler>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
