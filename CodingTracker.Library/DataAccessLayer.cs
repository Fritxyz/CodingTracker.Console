using Dapper;
using System.Data;
using System.Data.SQLite;

namespace CodingTracker.Library
{
    internal class DataAccessLayer
    {
        private readonly string _connectionString;

        internal DataAccessLayer(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<T> LoadData<T, U>(string sqlCommand, U parameters)
        {
            using IDbConnection connection = new SQLiteConnection(_connectionString);
            var rows = connection.Query<T>(sqlCommand, parameters).ToList();
            return rows;
        }

        internal void SaveData<T>(string sqlCommand, T parameters)
        {
            using IDbConnection connection = new SQLiteConnection(_connectionString);
            connection.Execute(sqlCommand, parameters);
        }
    }
}
