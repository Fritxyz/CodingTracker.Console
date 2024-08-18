using CodingTracker.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    internal class Helpers
    {
        private static readonly CodingSession _codingSession = new();

        internal DateTime EnterDatePrompt()
        {
            bool isDateTimeParsed = false;
            do
            {
                Console.Write("Please enter a date and time (e.g., 2024-08-10 14:30):");
                string? startDateStr = Console.ReadLine();

                isDateTimeParsed = DateTime.TryParseExact(
                    startDateStr,
                    "yyyy-MM-dd HH:mm",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out _codingSession.StartTime
                );

                if (isDateTimeParsed)
                {
                    Console.WriteLine($"Date Parsed: {_codingSession.StartTime}");
                }
                else
                {
                    Console.WriteLine("Not Success");
                }
            } while (isDateTimeParsed);
            
        }
    }
}
