using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperGenericDataManager;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Shared;

namespace DataAccess
{
    public class MySQLConnection : IDbConnectionFactory
    {
        private DBConnectionSettings _dbConnSettings;
        public MySQLConnection(IOptions<DBConnectionSettings> dbConnectionOptions)
        {
            _dbConnSettings = dbConnectionOptions.Value;
        }

        public DbConnection CreateConnection()
        {
            var connection = new MySqlConnection(_dbConnSettings.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
