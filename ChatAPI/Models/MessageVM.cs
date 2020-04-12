using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Models
{
    public class MessageVM
    {
        public int ID { get; set; }
        public int RecipientID { get; set; }
        public int SenderID { get; set; }
        public string Contents { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
