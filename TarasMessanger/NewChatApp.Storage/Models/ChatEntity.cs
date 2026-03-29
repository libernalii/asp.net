using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Storage.Models
{
    public class ChatEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
        public string? Name { get; set; }
    }
}
