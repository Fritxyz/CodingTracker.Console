using CodingTracker.Library.Models;
using Microsoft.Extensions.Configuration;
using Spectre.Console;
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

        #region ViewData
        internal static void ViewData()
        {
            // retrieve all data from the database
            const string command = @"SELECT Id, StartTime, EndTime, Duration AS DurationString 
                                     FROM coding_session;";

            List<CodingSession> datas = _layer.LoadData<CodingSession, dynamic>(command, new { });

            // create a table
            var spectretable = new Table();

            spectretable.AddColumn("Id");
            spectretable.AddColumn("Date Started");
            spectretable.AddColumn("Date Ended");
            spectretable.AddColumn("Duration");

            foreach (var data in datas)
            {
                spectretable.AddRow(
                    data.Id.ToString(),
                    data.StartTime.ToString(),
                    data.EndTime.ToString(),
                    data.Duration.ToString()
                );
            }

            AnsiConsole.Write(spectretable);
        }
        #endregion

        #region InsertingData
        internal static void InsertingData(DateTime startTime, DateTime endTime, TimeSpan duration)
        {
            const string command = @"INSERT INTO coding_session (StartTime, EndTime, Duration) 
                                     VALUES (@StartTime, @EndTime, @Duration);";

            Console.WriteLine(startTime.ToString());

            _layer.SaveData(
                command,
                new
                {
                    StartTime = startTime.ToString(),
                    EndTime = endTime.ToString(),
                    Duration = duration.ToString()
                }
            );
        }
        #endregion

        #region DeleteData
        internal static bool DeleteData(int id)
        {
            // find the data using id
            string command = @"SELECT Id, StartTime, EndTime, Duration AS DurationString 
                               FROM coding_session;";

            List<CodingSession> datas = _layer.LoadData<CodingSession, dynamic>(command, new { id });

            // if the count of data returned is less than 0
            if (datas.Count == 0)
                return false;

            command = @"DELETE FROM coding_session WHERE Id=@id;";

            _layer.SaveData(command, new { id });

            command = @"SELECT Id, StartTime, EndTime, Duration AS DurationString 
                        FROM coding_session;";

            datas = _layer.LoadData<CodingSession, dynamic>(command, new { id });

            return datas.Count != 0;
        }
        #endregion

        #region GetAllIds
        internal static List<int> GetAddIds()
        {
            const string command = "SELECT Id FROM coding_session";

            return _layer.LoadData<int, dynamic>(command, new { }).ToList();
        }
        #endregion

        #region UpdateData
        internal static void UpdateData(int id, DateTime startTime, DateTime endTime, TimeSpan duration)
        {
            const string command = @"UPDATE coding_session 
                                     SET StartTime = @startTime, EndTime = @endTime, Duration = @duration
                                     WHERE Id = @id;";

            _layer.SaveData(command, new {id, startTime, endTime, duration});
        }
        #endregion
    }
}
