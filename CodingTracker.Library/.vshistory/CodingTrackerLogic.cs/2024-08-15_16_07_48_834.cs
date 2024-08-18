using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.Design;
using CodingTracker.Library.Models;
using CodingTracker.Library;

namespace HabitLogger.Library
{
    public static class CodingTrackerLogic
    {
        private static readonly CodingSession _codingSession = new();
        private static readonly Helpers _helpers = new();
        private static readonly Validations _validations = new();

        #region ChoiceMade Method
        public static void ChoiceMade(string input)
        {
            if (Regex.IsMatch(input, "[01234]"))
            {
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;

                    case "1":
                        Console.WriteLine("View Data");
                        CodingTrackerCrud.ViewData();

                        break;

                    case "2":
                        Console.WriteLine("Insert Data");

                        // todo: test this program again, so that we can find the bugs 
                        while (true)
                        {
                            _codingSession.StartTime = _helpers.EnterDatePrompt("Please enter date and time (e.g., 2024-08-10 14:30:20)");
                            if (_codingSession.StartTime == default) break;

                            _codingSession.EndTime = _helpers.EnterDatePrompt("Please enter another date and time (e.g., 2024-08-10 14:30:20)");
                            if (_codingSession.EndTime == default) break;

                            if (!_validations.DateTimeValidations(_codingSession.StartTime, _codingSession.EndTime))
                            {
                                Console.WriteLine("Error. Please try again.");
                            }
                            else
                            {
                                _codingSession.Duration = _helpers.DurationFormula(_codingSession.StartTime, _codingSession.EndTime);

                                CodingTrackerCrud.InsertingData(
                                    _codingSession.StartTime,
                                    _codingSession.EndTime,
                                    _codingSession.Duration
                                );

                                Console.WriteLine("Data Inserted Successfully");
                                break;
                            }
                        }

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
