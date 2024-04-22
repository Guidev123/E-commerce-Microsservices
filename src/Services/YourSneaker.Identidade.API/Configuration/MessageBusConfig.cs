using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourSneaker.Core.Tools;
using YourSneaker.MessageBus;

namespace YourSneaker.Identidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
