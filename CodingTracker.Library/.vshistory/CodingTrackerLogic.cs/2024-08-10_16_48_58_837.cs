using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace HabitLogger.Library
{
    public static class CodingTrackerLogic
    {
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

                        bool parsedDateTime = DateTime.TryParse(startDateStr, out DateTime parsedDateTime);
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
