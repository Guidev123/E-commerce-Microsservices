using YourSneaker.MessageBus;
using YourSneaker.Core.Tools;
using YourSneaker.Carrinho.API.Services;

namespace YourSneaker.Carrinho.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                                  .AddHostedService<CarrinhoIntegrationHandler>();
        }
    }
}
