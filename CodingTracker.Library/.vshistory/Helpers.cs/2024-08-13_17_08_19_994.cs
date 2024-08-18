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
        internal DateTime EnterDatePrompt(string text)
        {
            bool isDateTimeParsed = false;
            DateTime output = default;
            string? dateStr;
            do
            {
                Console.Write($"{text} or enter 0 to be back in main menu: ");
                dateStr = Console.ReadLine();

                if (dateStr == "0") break;
               
                isDateTimeParsed = DateTime.TryParseExact(
                    dateStr,
                    "yyyy-MM-dd HH:mm:ss",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDateTime
                );

                output = parsedDateTime;
   
                if(!isDateTimeParsed)
                {
                    Console.WriteLine("Invalid DateTime. Please try again.");
                }
            } while (!isDateTimeParsed);
            
            return output;
        }

        internal TimeSpan DurationFormula(DateTime startTime, DateTime endTime) => endTime - startTime;
    }
}
