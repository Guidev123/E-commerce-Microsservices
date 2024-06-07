using MediatR;

namespace YourSneaker.Clientes.API.Aplication.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //envia confirmacao atraves de evento

            return Task.CompletedTask;
        }
    }
}
