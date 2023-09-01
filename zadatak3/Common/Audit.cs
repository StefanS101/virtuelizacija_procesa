using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Audit
    {
        private string id;
        private DateTime timeStamp;
        private MessageTypes messageType;
        private string message;

        public Audit(string id, DateTime timeStamp, MessageTypes messageType, string message)
        {
            this.Id = id;
            this.TimeStamp = timeStamp;
            this.MessageType = messageType;
            this.Message = message;
        }

        public string Id { get => id; set => id = value; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        public MessageTypes MessageType { get => messageType; set => messageType = value; }
        public string Message { get => message; set => message = value; }
    }
}
