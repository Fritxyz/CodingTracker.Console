﻿using System;
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
                        Console.WriteLine("\nView Data");
                        CodingTrackerCrud.ViewData();
                        break;

                    case "2":
                        Console.WriteLine("\nInsert Data");

                        do
                        {
                            _codingSession.StartTime = Helpers.EnterDatePrompt("Please enter date and time (e.g., 2023-12-25 16:30:20)");
                            if (_codingSession.StartTime == default) break;

                            _codingSession.EndTime = Helpers.EnterDatePrompt("Please enter another date and time (e.g., 2023-12-25 16:30:20)");
                            if (_codingSession.EndTime == default) break;

                            if (!Validations.DateTimeValidations(_codingSession.StartTime, _codingSession.EndTime))
                            {
                                Console.WriteLine("\nError. Please try again.\n");
                            }
                            else
                            {
                                _codingSession.Duration = Helpers.DurationFormula(_codingSession.StartTime, _codingSession.EndTime);

                                CodingTrackerCrud.InsertingData(
                                    _codingSession.StartTime,
                                    _codingSession.EndTime,
                                    _codingSession.Duration
                                );

                                Console.WriteLine("\nData Inserted Successfully\n");
                            }
                        } while (!Validations.DateTimeValidations(_codingSession.StartTime, _codingSession.EndTime));

                        break;

                    case "3":
                        Console.WriteLine("\nDelete Data");
                        CodingTrackerCrud.ViewData();

                        _codingSession.Id = Helpers.EnterIdPrompt();
                        if (_codingSession.Id <= 0)
                        {
                            bool isDataDeleted = CodingTrackerCrud.DeleteData(_codingSession.Id);

                            if (!isDataDeleted)
                                Console.WriteLine("Data is not deleted. Please try again.");
                            else
                                Console.WriteLine("Data Successfully Deleted");
                        }

                        break;

                    case "4":
                        Console.WriteLine("\nUpdate Data");
                        CodingTrackerCrud.ViewData();

                        _codingSession.Id = Helpers.EnterIdPrompt();

                        if (_codingSession.Id <= 0)
                        {
                            do
                            {
                                _codingSession.StartTime = Helpers.EnterDatePrompt("Please enter date and time (e.g., 2023-12-25 16:30:20)");
                                if (_codingSession.StartTime == default) break;

                                _codingSession.EndTime = Helpers.EnterDatePrompt("Please enter another date and time (e.g., 2023-12-25 16:30:20)");
                                if (_codingSession.EndTime == default) break;

                                if (!Validations.DateTimeValidations(_codingSession.StartTime, _codingSession.EndTime))
                                {
                                    Console.WriteLine("\nError. Please try again.\n");
                                }
                                else
                                {
                                    _codingSession.Duration = Helpers.DurationFormula(_codingSession.StartTime, _codingSession.EndTime);

                                    CodingTrackerCrud.UpdateData(
                                        _codingSession.Id,
                                        _codingSession.StartTime,
                                        _codingSession.EndTime,
                                        _codingSession.Duration
                                    );

                                    Console.WriteLine("\nData Updated Successfully.\n");
                                }
                            } while (!Validations.DateTimeValidations(_codingSession.StartTime, _codingSession.EndTime));
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
            }
        }
        #endregion
    }
}