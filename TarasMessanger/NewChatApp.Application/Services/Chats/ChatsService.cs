using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Chats;

namespace NewChatApp.Application.Services.Chats;

public class ChatsService
{
    private readonly IChatsRepository _repository;

    public ChatsService(IChatsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChatBase[]> GetMyChats()
    {
        // просто тестовий userId
        var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        return await _repository.GetAll(userId, 20, 0);
    }
}