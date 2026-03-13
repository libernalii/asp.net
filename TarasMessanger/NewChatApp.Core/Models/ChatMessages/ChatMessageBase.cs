namespace NewChatApp.Core.Models.ChatMessages;

public abstract class ChatMessageBase
{
    public Guid Id { get; set; }
    public DateTime SendAt { get; set; }
    public Guid SenderId { get; set; }
    public Guid ChatId { get; set; }

    public ChatMessageStatus Status { get; set; }

    public string Content { get; set; }
}

public enum ChatMessageStatus
{
    Sending,
    Sent,
    Read,
    Deleted
}