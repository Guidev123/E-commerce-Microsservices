using MediatR;
using YourSneaker.Core.Messages.Integration;
using YourSneaker.MessageBus;

namespace YourSneaker.Pedido.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus messageBus)
        {
            _bus = messageBus;
        }


        public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new PedidoRealizadoIntegrationEvent(message.ClienteId));
        }
    }
}
