using CodingTracker.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library
{
    internal static class Helpers
    {
        #region EnterDatePrompt
        internal static DateTime EnterDatePrompt(string text, DateTime dateTime)
        {
            DateTime output = default;
            string? dateString;
            bool isDateTimeParsed;

            do
            {
                Console.Write($"{text} or enter 0 to be back in main menu: ");
                dateString = Console.ReadLine();

                if (dateString == "0") break;

                isDateTimeParsed = DateTime.TryParseExact(
                    dateString,
                    "yyyy-MM-dd HH:mm:ss",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out dateTime
                );

                output = parsedDateTime;

                if (!isDateTimeParsed)
                    Console.WriteLine("\nInvalid DateTime. Please try again.\n");
            } while (!isDateTimeParsed);

            return output;
        }
        #endregion

        #region DurationFormula
        internal static TimeSpan DurationFormula(DateTime startTime, DateTime endTime) => endTime - startTime;
        #endregion

        #region EnterIdPrompt
        internal static int EnterIdPrompt()
        {
            int parsedId = 0;
            bool isIdParsed;

            do
            {
                Console.Write("Enter an Id or enter '0' to be back in main menu: ");

                string? idString = Console.ReadLine();

                if (idString == "0") break;

                isIdParsed = int.TryParse(idString, out parsedId);

                if (!isIdParsed)
                    Console.WriteLine("\nInvalid Id. Please try again\n");

                if (!CodingTrackerCrud.GetAddIds().Contains(parsedId))
                    Console.WriteLine("\nThe ID doesn't exist in the database.\n");
            } while (!isIdParsed || !CodingTrackerCrud.GetAddIds().Contains(parsedId));

            return parsedId;
        }
        #endregion
    }
}
