using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Core.Models.ChatMessages
{
    public sealed class FileChatMessage : ChatMessageBase
    {
        public ICollection<FileItem> Files { get; set; } = new List<FileItem>();
    }

    public class FileItem
    {
        public required string FileName { get; set; }
        public required string FilePath { get; set; }
        public long Size { get; set; }
    }
}
