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
        public static bool ChoiceMade(string input)
        {
            if(Regex.IsMatch(input, "[01234]"))
            {
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                        
                    case "1":
                        Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            return false;
        }
        #endregion
    }
}
