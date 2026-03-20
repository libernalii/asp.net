using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Users;
using NewChatApp.Shared.Common;
using NewChatApp.Storage.Models;

namespace NewChatApp.Storage.Repositories;

public sealed class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(SqlConnectionFactory connectionFactory, IUnitOfWork unitOfWork) : base(connectionFactory, unitOfWork)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<PagedList<User>> SearchUsers(SearchOptions options)
    {
        options.SearchText = $"%{options.SearchText}%";
        
        var sql = @"SELECT [id], [nickname], [email], count(*) OVER() AS 'total_count' FROM [users] 
WHERE [nickname] LIKE @searchText
ORDER BY [id]
OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

        var users = (await SelectWithRetry<UserEntity, SearchOptions>(sql, options)).ToArray();

        return new PagedList<User>
        {
            Items = users.Select(x => new User
            {
                Id = x.Id,
                Email = x.Email,
                Nickname = x.Nickname
            }).ToArray(),
            Limit = options.Limit,
            Offset = options.Offset,
            TotalCount = users.FirstOrDefault()?.TotalCount ?? 0
        };
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