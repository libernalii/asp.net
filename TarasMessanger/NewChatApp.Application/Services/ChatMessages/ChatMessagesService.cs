using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.ChatMessages;

namespace NewChatApp.Application.Services.ChatMessages;

public class ChatMessagesService
{
    private readonly IChatMessagesRepository _repository;

    public ChatMessagesService(IChatMessagesRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChatMessageBase[]> GetMessages(Guid chatId)
    {
        return await _repository.Get(chatId, 50, 0);
    }
}