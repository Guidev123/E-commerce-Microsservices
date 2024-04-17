using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSneaker.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.Now;   
        }
    }
}
