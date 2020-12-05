using System;
namespace Capstone.Utilities
{
    public static class UserString
    {
        public static bool IsLessThanOrEqualTo(int length, string str)
        {
            if (str.Length <= length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
