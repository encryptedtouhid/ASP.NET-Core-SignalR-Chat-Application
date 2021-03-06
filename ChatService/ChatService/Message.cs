﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatSample
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
       
    }
}
