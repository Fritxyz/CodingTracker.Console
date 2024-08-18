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
        internal DataAccessLayer(string connec)
        {
            string connectionString
        }

        internal List<T> LoadData<T, U>(string sqlCommand, U parameters)
        {
            using IDbConnection connection = new SQLiteConnection(connectionString);
            var rows = connection.Query<T>(sqlCommand, parameters).ToList();
            return rows;
        }

        internal void SaveData<T>(string sqlCommand, T parameters)
        {
            using IDbConnection connection = new SQLiteConnection(connectionString);
            connection.Execute(sqlCommand, parameters);
        }
    }
}
