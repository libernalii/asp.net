using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models;
using NewChatApp.Core.Models.Users;

namespace NewChatApp.Storage.Repositories;

public sealed class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(SqlConnectionFactory connectionFactory, IUnitOfWork unitOfWork) : base(connectionFactory, unitOfWork)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<User[]> SearchUsers(SearchOptions options)
    {
        options.SearchText = $"%{options.SearchText}%";
        
        var sql = @"SELECT [id], [nickname], [email] FROM [users] 
WHERE [nickname] LIKE @searchText
ORDER BY [id]
OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

        return (await SelectWithRetry(sql, options)).ToArray();
    }

    public ValueTask<User?> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> Get(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> Add(User user)
    {
        var sql = @"INSERT INTO [users](id, nickname, email, created_at, password_hash) OUTPUT inserted.*
VALUES (@id, @nickname, @email, @createdAt, @passwordHash)";

        return InsertWithRetry(sql, user);
    }

    public Task<User> Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task Delete(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailUnique(string email)
    {
        throw new NotImplementedException();
    }
}