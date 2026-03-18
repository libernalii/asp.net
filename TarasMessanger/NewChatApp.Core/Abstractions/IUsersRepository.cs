using NewChatApp.Core.Models.Users;

namespace NewChatApp.Core.Abstractions;

public interface IUsersRepository
{
    Task<User[]> SearchUsers(SearchOptions options);
    ValueTask<User?> Get(Guid id);
    ValueTask<User?> Get(string email);
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task Delete(User user);
    Task<bool> IsEmailUnique(string email);
}

public class SearchOptions
{
    public string? SearchText { get; set; }
    public int Limit { get; set; } = 10;
    public int Offset { get; set; } = 0;
}