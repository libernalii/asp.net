using System.Data;
using Dapper;
using NewChatApp.Core.Abstractions;

namespace NewChatApp.Storage.Repositories;

public abstract class RepositoryBase<T> where T : class
{ 
    private readonly IDbConnection _connection;
    private IUnitOfWork _unitOfWork;
    private const int RetryCount = 3;
    
    public RepositoryBase(SqlConnectionFactory connectionFactory, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _connection = connectionFactory.GetConnection();
    }

    public async Task<T> InsertWithRetry(string sql, T entity)
    {
        var retries = 0;

        while (retries <= RetryCount)
        {
            try
            {
                var addedEntity = await _connection.QuerySingleAsync<T>(sql, entity, _unitOfWork.Transaction);
                
                return addedEntity;
            }
            catch (Exception)
            {
                if (retries == RetryCount)
                {
                    throw;
                }

                retries++;
                await Task.Delay((retries + 1) * 1000);
            }
        }
        
        throw new Exception("Failed to insert entity");
    }
    
    public async Task<IEnumerable<T>> SelectWithRetry<TOptions>(string sql, TOptions options)
    {
        var retries = 0;

        while (retries <= RetryCount)
        {
            try
            {
                return await _connection.QueryAsync<T>(sql, options, _unitOfWork.Transaction);
            }
            catch (Exception)
            {
                if (retries == RetryCount)
                    throw;

                retries++;
                await Task.Delay((retries + 1) * 1000);
            }
        }
        
        throw new Exception("Failed to insert entity");
    }
}