using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Chats;

namespace NewChatApp.Storage.Repositories;

public class ChatsRepository : IChatsRepository
{
    public Task<ChatBase[]> GetAll(Guid userId, int limit, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<ChatBase> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ChatBase> Add(ChatBase chat)
    {
        throw new NotImplementedException();
    }

    public Task Delete(ChatBase chat)
    {
        throw new NotImplementedException();
    }
}