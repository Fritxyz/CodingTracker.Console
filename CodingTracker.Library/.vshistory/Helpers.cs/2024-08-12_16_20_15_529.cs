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
        internal DateTime EnterDatePrompt()
        {
            bool isDateTimeParsed = false;
            DateTime output;

            do
            {
                Console.Write("Please enter a date and time (e.g., 2024-08-10 14:30):");
                string? startDateStr = Console.ReadLine();

                isDateTimeParsed = DateTime.TryParseExact(
                    startDateStr,
                    "yyyy-MM-dd HH:mm",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out output
                );
   
                if(!isDateTimeParsed)
                {
                    Console.WriteLine("Invalid DateTime. Please try again.");
                }
            } while (!isDateTimeParsed);
            
            return output;
        }

        internal TimeSpan DurationFormula(DateTime startDate, DateTime endTime) => endTime - startDate;
    }
}
