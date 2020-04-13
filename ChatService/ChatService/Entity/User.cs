using System;
using System.Collections.Generic;

namespace ChatService.Entity
{
    public partial class User
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public Guid? UserUniqueCode { get; set; }
        public string ConnectionId { get; set; }
        public string Status { get; set; }
    }
}
