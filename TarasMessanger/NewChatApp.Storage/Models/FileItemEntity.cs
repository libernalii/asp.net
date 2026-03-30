using System;
using System.Collections.Generic;
using System.Text;

namespace NewChatApp.Storage.Models
{
    public class FileItemEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long Size { get; set; }
    }
}
