

using YourSneaker.Core.Messages.Integration;
using YourSneaker.MessageBus;
using YourSneaker.Pedido.API.Application.Queries;

namespace YourSneaker.Pedido.API.Services
{
    public class PedidoGerenciadorIntegrationHandler : IHostedService, IDisposable
    {
        private readonly ILogger<PedidoGerenciadorIntegrationHandler> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public PedidoGerenciadorIntegrationHandler(ILogger<PedidoGerenciadorIntegrationHandler> logger, IServiceProvider serviceProvider = null)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedido começou");

            _timer = new Timer(ProcessarPedidos, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        private async void ProcessarPedidos(object sale)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var pedidoQueries = scope.ServiceProvider.GetRequiredService<IPedidoQueries>();
                var pedido = await pedidoQueries.ObterPedidosAutorizados();

                if (pedido == null) return; 

                var bus = scope.ServiceProvider.GetRequiredService<IMessageBus>();

                var pedidoAutorizado = new PedidoAutorizadoIntegrationEvent(pedido.ClienteId, pedido.Id,
                                        pedido.PedidoItems.ToDictionary(p => p.ProdutoId, p => p.Quantidade));

                await bus.PublishAsync(pedidoAutorizado);
                _logger.LogInformation($"Pedido ID: {pedido.Id} foi encaminhado para dimunuição no estoque");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de pedido acabou");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
