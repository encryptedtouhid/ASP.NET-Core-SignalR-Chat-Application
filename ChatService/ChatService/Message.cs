using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatSample
{
    public partial class Message
    {
        public int Id { get; set; }
        public string RecipientConnectionId { get; set; }
       public string Recipient { get; set; }
        public string SenderConnectionId { get; set; }
        public string Sender { get; set; }
        public string Contents { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
