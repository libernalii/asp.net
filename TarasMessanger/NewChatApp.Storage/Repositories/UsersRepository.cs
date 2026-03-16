using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models;

namespace NewChatApp.Storage.Repositories;

public sealed class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<User[]> SearchUsers(SearchOption options)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> Get(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Add(User user)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        await using var connection = new SqlConnection(connectionString);
        
        connection.Open();
        var sql = @"INSERT INTO [users](id, nickname, email, created_at, password_hash) OUTPUT inserted.id
VALUES (@Id, @Nickname, @Email, @CreatedAt, @PasswordHash)";

        var addedUserId = connection.QuerySingle<User>(sql, user);
        
        return user;
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