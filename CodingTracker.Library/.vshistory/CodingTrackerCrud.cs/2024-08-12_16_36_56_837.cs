using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    public static class CodingTrackerCrud
    {
        private static readonly DataAccessLayer _layer = new(GetConnectionString());

        #region GetConnectionString
        private static string GetConnectionString(string connectionString = "Default")
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            var config = build.Build();

            string? output = config.GetConnectionString(connectionString);

            return output!;
        }
        #endregion

        #region CreateTable
        public static void CreateTable()
        {
            const string command = @"CREATE TABLE IF NOT EXISTS coding_session (
	                            Id INTEGER NOT NULL,
	                            StartTime TEXT NOT NULL,
                                EndTime TEXT NOT NULL,
	                            Duration TEXT NOT NULL,
	                            PRIMARY KEY(Id AUTOINCREMENT)
                               );";

            _layer.SaveData(command, new { });
        }
        #endregion

        #region InsertingData
        public static void InsertingData(DateTime startTime, DateTime endTime, TimeSpan duration)
        {
            const string command = @"INSERT INTO coding_session (StartTime, EndTime, Duration) 
                                     VALUES (startTime, endTime, duration);";

            _layer.SaveData(command, new { StartTime = startTime, EndTime = endTime, Duration = duration });
        }
        #endregion
    }
}
