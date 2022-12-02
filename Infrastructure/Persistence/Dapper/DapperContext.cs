using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistence;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Persistence.Dapper
{
    public class DapperContext : IDapperContext
    {
        private string ConnectionString { get; set; }

        public DapperContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqliteConnection Connection()
        {
            return new SqliteConnection(ConnectionString);
        }

        public async Task<List<T>> GetAll<T>(string query)
        {
            await using (var connection = Connection())
            {
               return (await connection.QueryAsync<T>(query)).ToList();
            }
        }

        public async Task<T> Get<T>(string query)
        {
            await using (var connection = Connection())
            {
               return (await connection.QueryFirstAsync<T>(query));
            }
        }
    }
}