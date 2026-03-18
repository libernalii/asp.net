using System.Data;

namespace NewChatApp.Core.Abstractions;

public interface IUnitOfWork
{
    IDbTransaction Transaction { get; }
    
    void Commit();
    void Rollback();
}