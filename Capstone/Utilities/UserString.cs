using System;
using System.Text.RegularExpressions;

namespace Capstone.Utilities
{
    public static class UserStr
    {
        /*
        User input string validation utiltity.
            Length, email, and special characters check
         */
        public static bool IsLengthOverLimit(int length, string str)
        {
            if (str.Length <= length) return false;
            else return true;
        }

        public static bool IsValidEmail(string email)
        {
            // Citation: [1] Email Regex
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email);
        }

        public static bool ContainsSpecialChar(string str)
        {
            if (str.Contains("!") || str.Contains("@") || str.Contains("#") || str.Contains("$") || str.Contains("%") || str.Contains("^") || str.Contains("&") || str.Contains("*") || str.Contains("(") || str.Contains(")") || str.Contains(".") || str.Contains(",") || str.Contains(">") || str.Contains("<") || str.Contains("{") || str.Contains("}") || str.Contains("[") || str.Contains("]") || str.Contains("?") || str.Contains("~") || str.Contains("`") || str.Contains(";")) return true;
            else return false; 
        }

        /* Citations
         * 1 - Email Regex: https://emailregex.com/
         */
    }
}
