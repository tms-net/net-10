using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppForBankoOperatons.Accounts;

namespace ConsoleAppForBankoOperatons
{
    internal class Transeaction
    {
        private bool TranseCompleted;
        public string TranseactionID;
        public string TranseactionCode;
        public double TranseactionValue;
        public string TranseactionValueCurrancyCode;
        public DateTime transeDate;

        internal Transeaction(string transeactionCode, double transeactionValue, string transeactionValueCurrancyCode, DateTime traseDate = default)
        {
            TranseactionID = Guid.NewGuid().ToString();
            TranseactionCode = transeactionCode;
            TranseactionValue = transeactionValue;
            TranseactionValueCurrancyCode = transeactionValueCurrancyCode;
            if (traseDate != default)
                transeDate = traseDate;
            else
                transeDate = DateTime.Now;
        }

        public string Dotranseaction(BankAccount from, BankAccount to, List<СurrencyConverter>? converter = null)
        {
            double converterCoefficent = 0;
            if (TranseactionValueCurrancyCode != "933")
            {
                if (converter != null && converter.Count > 0) 
                {
                    for (int i = 0; i < converter.Count; i++)
                    {
                        if (converter[i].СurrencyCode == TranseactionValueCurrancyCode && converter[i].DateOn <= transeDate && converter[i].DateOff >= transeDate)
                        {
                            converterCoefficent = converter[i].CurrencyCoefficient;
                            break;
                        }
                    }
                    if (converterCoefficent == 0)
                    {
                        return $"Currency coefficent for {TranseactionValueCurrancyCode} didn't find on {transeDate}";
                    }
                }
                else
                    throw new ArgumentNullException("List of converter is empty");
            }
            if (from.DeductFundFromAccount(TranseactionValue * converterCoefficent))
            {
                to.AddFundToAccount(TranseactionValue * converterCoefficent);
                TranseCompleted = false;
                return "Operation completed";
            }
            TranseCompleted = false;
            return "Not enought cash";
        }
    }
}
