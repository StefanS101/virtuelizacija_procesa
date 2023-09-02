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
        private int id;
        private DateTime timeStamp;
        private MessageTypes messageType;
        private string message;
        public static int count = 0;

        public Audit(DateTime timeStamp, MessageTypes messageType, string message)
        {
            count++;
            this.Id = count;
            this.TimeStamp = timeStamp;
            this.MessageType = messageType;
            this.Message = message;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        [DataMember]
        public MessageTypes MessageType { get => messageType; set => messageType = value; }
        [DataMember]
        public string Message { get => message; set => message = value; }
    }
}
