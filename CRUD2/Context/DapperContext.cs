using System.Data;
using System.Data.SqlClient;

namespace CRUD2.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration= configuration;
            connectionString = _configuration.GetConnectionString("sqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
