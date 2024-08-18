using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    internal class DataAccessLayer
    {
        internal List<T> LoadData<T, U>(string sqlCommand, U parameters, string connectionString)
        {
            using IDbConnection connection = new SQLiteConnection(connectionString);

            var rows = connection.Query<T>(sqlCommand, parameters).ToList();
            return rows;
        }
    }
}
