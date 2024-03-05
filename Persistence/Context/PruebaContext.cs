using System.Data;
using Microsoft.Data.SqlClient;

namespace Persistence.Context
{
    public class PruebaContext
	{
        private readonly string _connectionString;

        public PruebaContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

