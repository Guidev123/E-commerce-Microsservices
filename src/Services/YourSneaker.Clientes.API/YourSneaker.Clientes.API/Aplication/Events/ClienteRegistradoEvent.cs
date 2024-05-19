using YourSneaker.Clientes.API.Models;
using YourSneaker.Core.DomainObjects;
using YourSneaker.Core.Messages;

namespace YourSneaker.Clientes.API.Aplication.Events
{
    public class ClienteRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public ClienteRegistradoEvent(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
