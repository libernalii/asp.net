using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Storage.Models
{
    public class ChatMessageEntity
    {
        public Guid Id { get; set; }
        public DateTime SendAt { get; set; }
        public Guid SenderId { get; set; }
        public Guid ChatId { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
    }
}
