namespace NewChatApp.Core.Models.Chats;

public class GroupChat : GroupChatBase
{
    public GroupChat(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users, string name) : base(id, createdAt, users, name)
    {
    }
}