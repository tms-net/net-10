using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppForBankoOperatons.Accounts;

namespace ConsoleAppForBankoOperatons
{
    internal class Tranceaction
    {
        private bool TraceCompleted;
        public string TranceactionID;
        public string TranceactionCode;
        public double TranceactionValue;
        public string TranceactionValueCurrancyCode;
        public DateTime TranceDate;

        internal Tranceaction(string tranceactionCode, double tranceactionValue, string tranceactionValueCurrancyCode, DateTime traceDate = default)
        {
            TranceactionID = Guid.NewGuid().ToString();
            TranceactionCode = tranceactionCode;
            TranceactionValue = tranceactionValue;
            TranceactionValueCurrancyCode = tranceactionValueCurrancyCode;
            if (traceDate != default)
                TranceDate = traceDate;
            else
                TranceDate = DateTime.Now;
        }

        public string DoTranceaction(BankAccount from, BankAccount to, List<СurrencyConverter>? converter = null)
        {
            double converterCoefficent = 0;
            if (TranceactionValueCurrancyCode != "933")
            {
                if (converter != null && converter.Count > 0) 
                {
                    for (int i = 0; i < converter.Count; i++)
                    {
                        if (converter[i].СurrencyCode == TranceactionValueCurrancyCode && converter[i].DateOn <= TranceDate && converter[i].DateOff >= TranceDate)
                        {
                            converterCoefficent = converter[i].CurrencyCoefficient;
                        }
                    }
                    if (converterCoefficent == 0)
                    {
                        return $"Currency coefficent for {TranceactionValueCurrancyCode} didn't find on {TranceDate}";
                    }
                }
                else
                    throw new ArgumentNullException("List of converter is empty");
            }
            if (from.DeductFundFromAccount(TranceactionValue * converterCoefficent))
            {
                to.AddFundToAccount(TranceactionValue * converterCoefficent);
                TraceCompleted = false;
                return "Operation completed";
            }
            TraceCompleted = false;
            return "Not enought cash";
        }
    }
}
