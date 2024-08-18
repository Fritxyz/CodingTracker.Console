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
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input is empty. Please try again");
                return false;
            } 
            else if(input == "0")
            {

            }
        }
        #endregion
    }
}
