using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NewChatApp.Storage.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    protected readonly IConfiguration Configuration; 
    
    public RepositoryBase(IConfiguration configuration)
    {
        Configuration = configuration;
    }
}