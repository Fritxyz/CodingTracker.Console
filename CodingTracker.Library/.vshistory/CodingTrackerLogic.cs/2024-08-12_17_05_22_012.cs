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
                        
                        do
                        {
                            _codingSession.StartTime = _helpers.EnterDatePrompt();
                            _codingSession.EndTime = _helpers.EnterDatePrompt();

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
                        } while (true);
                        
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
