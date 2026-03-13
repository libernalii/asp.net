namespace NewChatApp.Core.Models.Chats;

public abstract class ChatBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    protected ChatBase(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users)
    {
        Id = id;
        CreatedAt = createdAt;
        Users = users;
    }
    
    protected ICollection<ChatUserRelation> Users { get; set; } = new HashSet<ChatUserRelation>();
}