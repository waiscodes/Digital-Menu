using System;
using System.Text.RegularExpressions;

namespace Capstone.Utilities
{
    public static class UserStr
    {
        public static bool IsLengthOverLimit(int length, string str)
        {
            if (str.Length <= length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email);
        }
    }
}
