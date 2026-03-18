using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NewChatApp.Storage;

public class SqlConnectionFactory : IAsyncDisposable
{
    private readonly IDbConnection _connection;
    
    public SqlConnectionFactory(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public IDbConnection GetConnection() => _connection;

    public async ValueTask DisposeAsync()
    {
        if (_connection is IAsyncDisposable connectionAsyncDisposable)
            await connectionAsyncDisposable.DisposeAsync();
        else
            _connection.Dispose();
    }
}