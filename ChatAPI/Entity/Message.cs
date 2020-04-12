using System;
using System.Collections.Generic;

namespace ChatAPI.Entity
{
    public partial class Message
    {
        public int Id { get; set; }
        public Guid? RecipientUniqueCode { get; set; }
        public Guid? SenderUniqueCode { get; set; }
        public string Contents { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
