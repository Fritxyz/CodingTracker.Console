using CodingTracker.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    internal class Helpers
    {
        #region EnterDatePrompt
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
        #endregion

        #region DurationFormula
        internal TimeSpan DurationFormula(DateTime startTime, DateTime endTime) => endTime - startTime;
        #endregion

        #region EnterIdPrompt
        internal int EnterIdPrompt()
        {
            int parsedId = 0;
            bool isIdParsed;

            do
            {
                Console.Write("Enter an Id or enter '0' to be back in main menu: ");

                string? idString = Console.ReadLine();

                if (idString == "0") break;

                isIdParsed = int.TryParse(idString, out parsedId);               

                if(!isIdParsed)
                    Console.WriteLine("Invalid Id. Please try again");

                if (!CodingTrackerCrud.GetAddIds().Contains(parsedId))
                    Console.WriteLine();
            } while (!isIdParsed);

            return parsedId;
        }
        #endregion
    }
}
