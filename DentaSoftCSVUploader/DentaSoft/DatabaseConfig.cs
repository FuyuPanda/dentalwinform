using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaSoft
{
    public static class DatabaseConfig
    {
        public static string ConnectionString { get; private set; }

        public static void Initialize(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
