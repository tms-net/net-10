using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    public static class Helper
    {
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public static bool IsUpperEnglishOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < 'A' || c > 'Z')
                    return false;
            }

            return true;
        }
    }
}
