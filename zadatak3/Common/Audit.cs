using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
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

        [DataMember]
        public string Id { get => id; set => id = value; }
        [DataMember]
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        [DataMember]
        public MessageTypes MessageType { get => messageType; set => messageType = value; }
        [DataMember]
        public string Message { get => message; set => message = value; }
    }
}
