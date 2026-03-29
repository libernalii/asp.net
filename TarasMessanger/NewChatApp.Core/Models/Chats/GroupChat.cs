using System.Diagnostics.CodeAnalysis;

namespace NewChatApp.Core.Models.Chats;

public class GroupChat : GroupChatBase
{
    [SetsRequiredMembers]
    public GroupChat(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users, string name)
        : base(id, createdAt, users, name)
    {
    }

}