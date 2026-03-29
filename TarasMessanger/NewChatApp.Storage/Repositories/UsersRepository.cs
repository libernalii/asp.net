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

    public async ValueTask<User?> Get(Guid id)
    {
        var sql = @"SELECT [id], [nickname], [email], [password_hash], [created_at]
                FROM [users]
                WHERE [id] = @id";

        var result = await SelectWithRetry<User, object>(sql, new { id });

        return result.FirstOrDefault();
    }

    public async ValueTask<User?> Get(string email)
    {
        var sql = @"SELECT [id], [nickname], [email], [password_hash], [created_at]
                FROM [users]
                WHERE [email] = @email";

        var result = await SelectWithRetry<User, object>(sql, new { email });

        return result.FirstOrDefault();
    }

    public Task<User> Add(User user)
    {
        var sql = @"INSERT INTO [users](id, nickname, email, created_at, password_hash) OUTPUT inserted.*
VALUES (@id, @nickname, @email, @createdAt, @passwordHash)";

        return InsertWithRetry(sql, user);
    }

    public async Task<User> Update(User user)
    {
        var sql = @"
UPDATE [users]
SET nickname = @nickname,
    email = @email,
    password_hash = @passwordHash
OUTPUT inserted.*
WHERE id = @id";

        return await InsertWithRetry(sql, user);
    }

    public async Task Delete(User user)
    {
        var sql = @"DELETE FROM [users] WHERE id = @id";

        await SelectWithRetry<object, object>(sql, new { user.Id });
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        var sql = @"SELECT COUNT(1) FROM [users] WHERE email = @email";

        var result = await SelectWithRetry<int, object>(sql, new { email });

        return result.FirstOrDefault() == 0;
    }
}