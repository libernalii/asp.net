using NewChatApp.Core.Models;

namespace NewChatApp.Core.Abstractions;

public interface IUsersRepository
{
    Task<User[]> SearchUsers(SearchOption options);
    ValueTask<User?> GetAsync(Guid id);
    ValueTask<User?> GetAsync(string email);
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task Delete(User user);
    Task<bool> IsEmailUnique(string email);
}

public record SearchOptions(string SearchText);