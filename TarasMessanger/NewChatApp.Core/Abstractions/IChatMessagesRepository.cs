using NewChatApp.Core.Models.ChatMessages;

namespace NewChatApp.Core.Abstractions;

public interface IChatMessagesRepository
{
    Task<ChatMessageBase[]> Get(Guid chatId, int limit, int offset);
    Task<List<ChatMessageBase>> GetByChat(Guid chatId);
    Task<ChatMessageBase> Add(ChatMessageBase message);
    Task<ChatMessageBase> Update(ChatMessageBase message);
}