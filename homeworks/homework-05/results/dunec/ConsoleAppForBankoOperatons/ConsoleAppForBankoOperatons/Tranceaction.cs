using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class Tranceaction
    {
        public string TranceactionID;
        public string TranceactionCode;
        public string TranceactionValue;

        internal Tranceaction(string tranceactionCode, string tranceactionValue)
        {
            TranceactionID = Guid.NewGuid().ToString();
            TranceactionCode = tranceactionCode;
            TranceactionValue = tranceactionValue;
        }

        public bool DoTranceaction(BankAccount from, BankAccount to)
        {

            return false;
        }

    }
}
