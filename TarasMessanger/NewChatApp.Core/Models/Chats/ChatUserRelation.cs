namespace NewChatApp.Core.Models.Chats;

public class ChatUserRelation
{
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }

    public bool IsAdmin { get; set; }
}