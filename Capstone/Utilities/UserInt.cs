using System;
namespace Capstone.Utilities
{
    public class UserInt
    {
        /* User input validation for numbers
         * This was meant to keep the code dry. Only ended up being one method but more will be added here.
         */
        public static bool IsPositiveNumber(double num)
        {
            if (num >= 0) return true;
            else return false;
        }
    }
}
