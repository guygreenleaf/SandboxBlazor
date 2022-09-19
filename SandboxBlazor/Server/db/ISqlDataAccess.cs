using System.Data;

namespace SandboxBlazor.Server.db
{
    public interface ISqlDataAccess
    {
        Task ExecuteAsync<T>(string sql, T Parameters, bool log = false, string accessType = "", CommandType cmdType = CommandType.Text);
        

        Task<IEnumerable<T>> QueryAsync<T, U>(string sql, U parameters, bool log = false, string accessType = "", CommandType cmdType = CommandType.Text);
    }
}
