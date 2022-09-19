using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SandboxBlazor.Server.db
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private string _connectionString;
        private string _dbName;

        public SqlDataAccess(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            _dbName = dbName;
        }


        public async Task<IEnumerable<T>> QueryAsync<T, U>(string sql, U parameters, bool log = false, string accessType = "", CommandType cmdType = CommandType.Text)
        {
            using(IDbConnection connection = new SqlConnection(_connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters, commandType: cmdType);

                //if (log) { await SaveToLog(sql, parameters, cmdType); }

                return data;
            }
        }




        public async Task ExecuteAsync<T>(string sql, T parameters, bool log = false, string accessType = "", CommandType cmdType = CommandType.Text)
        {

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
               await connection.QueryAsync<T>(sql, parameters, commandType: cmdType);

                //if (log) { await SaveToLog(sql, parameters, cmdType); }
            }

        }
    }
}
