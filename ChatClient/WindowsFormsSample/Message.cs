using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsSample
{
    public partial class Message
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public Guid? RecipientUniqueCode { get; set; }
        public string Recipient { get; set; }
        public Guid? SenderUniqueCode { get; set; }
        public string Sender { get; set; }
        public string Contents { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
