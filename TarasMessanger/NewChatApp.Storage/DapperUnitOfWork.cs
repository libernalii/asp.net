using System.Data;
using NewChatApp.Core.Abstractions;

namespace NewChatApp.Storage;

public class DapperUnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IDbTransaction _transaction;
    
    public DapperUnitOfWork(SqlConnectionFactory connectionFactory)
    {
        var connection = connectionFactory.GetConnection();
        _transaction = connection.BeginTransaction();
    }
    
    public IDbTransaction Transaction { get => _transaction; private set; }
    
    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        _transaction.Dispose();
    }
}