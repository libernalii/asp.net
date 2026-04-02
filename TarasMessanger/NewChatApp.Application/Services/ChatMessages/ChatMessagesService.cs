using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.ChatMessages;

namespace NewChatApp.Application.Services.ChatMessages;

public class ChatMessagesService
{
    private readonly IChatMessagesRepository _repo;
    private readonly IUnitOfWork _uow;

    public ChatMessagesService(IChatMessagesRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<List<ChatMessageBase>> GetMessages(Guid chatId)
    {
        return await _repo.GetByChat(chatId);
    }

    public async Task SendText(Guid chatId, Guid userId, string text)
    {
        var msg = new TextChatMessage
        {
            Id = Guid.NewGuid(),
            ChatId = chatId,
            SenderId = userId,
            Content = text,
            SendAt = DateTime.UtcNow,
            Status = ChatMessageStatus.Sent
        };

        await _repo.Add(msg);
        _uow.Commit();
    }
}