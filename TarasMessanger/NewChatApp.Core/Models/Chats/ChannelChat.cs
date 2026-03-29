using System.Diagnostics.CodeAnalysis;

namespace NewChatApp.Core.Models.Chats;

public class ChannelChat : GroupChatBase
{
    [SetsRequiredMembers]
    public ChannelChat(Guid id, DateTime createdAt, ICollection<ChatUserRelation> users, string name)
         : base(id, createdAt, users, name)
    {
    }
}