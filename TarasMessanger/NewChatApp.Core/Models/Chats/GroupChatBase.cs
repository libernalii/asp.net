namespace NewChatApp.Core.Models.Chats;

public abstract class GroupChatBase : ChatBase
{
    protected GroupChatBase(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users, string name) : base(id, createdAt, users)
    {
        Name = name;
    }

    public required string Name { get; set; }
    public ICollection<ChatUserRelation> UsersRelations => Users;
}