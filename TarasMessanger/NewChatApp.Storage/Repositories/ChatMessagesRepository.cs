using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.ChatMessages;

namespace NewChatApp.Storage.Repositories;

public class ChatMessagesRepository : IChatMessagesRepository
{
    public Task<ChatMessageBase[]> Get(Guid chatId, int limit, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<ChatMessageBase> Add(ChatMessageBase message)
    {
        throw new NotImplementedException();
    }

    public Task<ChatMessageBase> Update(ChatMessageBase message)
    {
        throw new NotImplementedException();
    }
}