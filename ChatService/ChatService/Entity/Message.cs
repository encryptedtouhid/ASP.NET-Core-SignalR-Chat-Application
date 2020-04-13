using System;
using System.Collections.Generic;

namespace ChatService.Entity
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public DateTime? Timestamp { get; set; }
        public Guid? RecipientUniqueCode { get; set; }
        public Guid? SenderUniqueCode { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public string RecipientConnectionId { get; set; }
        public string SenderConnectionId { get; set; }
        public Guid? MessageUniqueCode { get; set; }
    }
}
