using NewChatApp.Core.Models;

namespace NewChatApp.Core.Abstractions;

public interface IUsersRepository
{
    Task<User[]> SearchUsers(SearchOption options);
    ValueTask<User?> Get(Guid id);
    ValueTask<User?> Get(string email);
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task Delete(User user);
    Task<bool> IsEmailUnique(string email);
}

public record SearchOptions(string SearchText);