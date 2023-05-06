using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class Сurrency
    {
        public string СurrencyNumber { get; }
        public string СurrencyCode { get; }

        public Сurrency(string number, string code)
        {
            if (number.Length != 3 || Different_functions.IsUpperEnglishOnly(number))
            {
                throw new ArgumentException($"Uncorrect Сurrency number: {nameof(number)}");
            }
            if (code.Length != 3 || Different_functions.IsDigitsOnly(code))
            {
                throw new ArgumentException($"Uncorrect Сurrency code: {nameof(code)}");
            }
            СurrencyNumber = number;
            СurrencyCode = code;
        }        
    }
    internal class СurrencyConverter
    {
        Сurrency CurrencyCopy{ get; }
        public double CurrencyCoefficient { get; set; }
        public DateTime DateOn { get; set; }
        public DateTime DateOff { get; set; }

        public СurrencyConverter(string number, double coefficient, string code, DateTime dateOn, DateTime dateOff = default)       
        {
            if (coefficient < 0)
            {
                throw new ArgumentException($"Uncorrect currency coefficient: {nameof(coefficient)}");
            }
            if (dateOn < dateOff)
            {
                throw new ArgumentException("Date off can't be earlier than Date on");
            }
            CurrencyCopy = new Сurrency(number, code);
            CurrencyCoefficient = coefficient;          
            DateOn = dateOn;
            DateOff = dateOff;
        }

        public void EditCurrencyParams(double coefficient, DateTime dateOn = default, DateTime dateOff = default)
        { 
            if (coefficient < 0)
            {
                throw new ArgumentException($"Uncorrect currency coefficient: {nameof(coefficient)}");
            }
            if (dateOn < dateOff)
            {
                throw new ArgumentException("Date off can't be earlier than Date on");
            }
            CurrencyCoefficient = coefficient;
            if (dateOn != default)
            {
                DateOn = dateOn;
            }
            if (dateOff != default)
            {
                DateOff = dateOff;
            }
        }
    }    
}
