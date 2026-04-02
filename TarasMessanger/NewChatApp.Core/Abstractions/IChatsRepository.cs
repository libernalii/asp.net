using NewChatApp.Core.Models.Chats;

namespace NewChatApp.Core.Abstractions;

public interface IChatsRepository
{
    Task<ChatBase[]> GetAll(Guid userId, int limit, int offset);
    Task<ChatBase> GetById(Guid chatId);
    //Task<T> Get<T>(Guid id) where T : ChatBase;
    Task<List<ChatBase>> GetUserChats(Guid userId);

    Task<ChatBase> Add(ChatBase chat);
    Task Delete(ChatBase chat);
}