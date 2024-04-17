using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.Messages;

namespace YourSneaker.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        //EVENT CONFIG
        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();
        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }
        public void RemoverEvento(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }
        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }
        //END



        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if(ReferenceEquals(null, a) && ReferenceEquals(b, null))
               return true;
            if(ReferenceEquals(null, a) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id ={Id}";
        }
    }
}
