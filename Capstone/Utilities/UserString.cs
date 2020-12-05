using System;
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
    }
}
