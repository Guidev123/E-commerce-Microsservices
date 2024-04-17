using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSneaker.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
