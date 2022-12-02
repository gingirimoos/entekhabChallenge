using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Application.Common.Interfaces.Persistence
{
    public interface IDapperContext
    {
        Task<List<T>> GetAll<T>(string query);
        Task<T> Get<T>(string query);
        public SqliteConnection Connection();
    }
}