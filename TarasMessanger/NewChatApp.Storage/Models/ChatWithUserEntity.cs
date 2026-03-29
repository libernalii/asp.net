using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Storage.Models
{
    public class ChatWithUserEntity : ChatEntity
    {
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
