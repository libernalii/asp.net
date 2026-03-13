namespace NewChatApp.Core.Models.Chats;

public sealed class PrivateChat : ChatBase
{
    public PrivateChat(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users) : base(id, createdAt, users)
    {
        if (users.Count != 2)
        {
            throw new ArgumentException("Private chat must have exactly 2 users");
        }
    }

    public IReadOnlyCollection<ChatUserRelation> UserRelations => Users.ToList().AsReadOnly();
}