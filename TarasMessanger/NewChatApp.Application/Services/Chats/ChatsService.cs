using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Chats;

namespace NewChatApp.Application.Services.Chats;

public class ChatsService
{
    private readonly IChatsRepository _repo;

    public ChatsService(IChatsRepository repo)
    {
        _repo = repo;
    }

    public Task<List<ChatBase>> GetUserChats(Guid userId)
    {
        return _repo.GetUserChats(userId);
    }

    public Task<ChatBase> GetById(Guid chatId)
    {
        return _repo.GetById(chatId);
    }
}