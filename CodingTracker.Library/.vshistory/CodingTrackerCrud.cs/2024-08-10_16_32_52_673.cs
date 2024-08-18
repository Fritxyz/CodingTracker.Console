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

        public static void CreateTable()
        {
            const string command = @"CREATE TABLE IF NOT EXISTS coding_session (
	                            Id INTEGER NOT NULL,
	                            StartTime TEXT NOT NULL,
                                EndTime TEXT NOT NULL,
	                            Duration TEXT NOT NULL,,
	                            PRIMARY KEY(Id AUTOINCREMENT)
                               );";

            _layer.SaveData(command, new { });
        }

        private static string GetConnectionString(string connectionString = "Default")
        {
            string? output = "";

            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = build.Build();

            output = config.GetConnectionString(connectionString);

            return output;
        }
    }
}
