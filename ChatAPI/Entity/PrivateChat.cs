using System;
using System.Collections.Generic;

namespace ChatAPI.Entity
{
    public partial class PrivateChat
    {
        public int Id { get; set; }
        public Guid? ChatUniqueCode { get; set; }
        public Guid? PartnerOneUniqueCode { get; set; }
        public Guid? PartnerTwoUniqueCode { get; set; }
    }
}
