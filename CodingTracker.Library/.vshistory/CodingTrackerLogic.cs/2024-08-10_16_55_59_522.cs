using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.Design;
using CodingTracker.Library.Models;

namespace HabitLogger.Library
{
    public static class CodingTrackerLogic
    {
        private static readonly CodingSession _codingSession = new();

        #region ChoiceMade Method
        public static void ChoiceMade(string input)
        {
            if(Regex.IsMatch(input, "[01234]"))
            {
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                        
                    case "1":
                        Console.WriteLine("View Data");

                        Console.Write("Please enter a date and time (e.g., 2024-08-10 14:30):");
                        string? startDateStr = Console.ReadLine();

                        bool isDateTimeParsed = DateTime.TryParseExact(
                            startDateStr, 
                            "yyyy-MM-dd HH:mm",
                            System.Globalization.DateTimeStyles.None
                            out _codingSession.StartTime,
                        );

                        if(isDateTimeParsed)
                        {
                            Console.WriteLine($"Date Parsed: {_codingSession.StartTime}");
                        }
                        else
                        {
                            Console.WriteLine("Not Success");
                        }

                        break;

                    case "2":
                        Console.WriteLine("Insert Data");
                        break;

                    case "3":
                        Console.WriteLine("Delete Data");
                        break;

                    case "4":
                        Console.WriteLine("Update Data");
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        #endregion
    }
}
