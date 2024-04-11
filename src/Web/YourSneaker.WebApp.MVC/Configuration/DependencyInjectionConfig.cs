using Polly;
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
                .AddHttpMessageHandler<HttpClientAuthDelegatingHandler>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
        }
    }
}

