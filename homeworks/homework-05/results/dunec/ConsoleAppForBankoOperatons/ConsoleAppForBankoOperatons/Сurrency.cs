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
            if (number.Length != 3 || !Helper.IsUpperEnglishOnly(number))
            {
                throw new ArgumentException("Uncorrect Сurrency number: " + number.ToString());
            }
            if (code.Length != 3 || !Helper.IsDigitsOnly(code))
            {
                throw new ArgumentException("Uncorrect Сurrency code: " + code.ToString());
            }
            СurrencyNumber = number;
            СurrencyCode = code;
        }
        public bool Equals(string nameOrCode)
        {
            return СurrencyNumber == nameOrCode || СurrencyCode == nameOrCode;
        }
    }

    internal class СurrencyConverter
    {
        public string СurrencyCode { get; }
        public double CurrencyCoefficient { get; set; }
        public DateTime DateOn { get; set; }
        public DateTime DateOff { get; set; }

        public СurrencyConverter(string code, double coefficient, DateTime dateOn, DateTime dateOff = default)
        {
            if (code.Length != 3 || !Helper.IsDigitsOnly(code))
            {
                throw new ArgumentException("Uncorrect Сurrency code: " + code.ToString());
            }
            if (coefficient < 0)
            {
                throw new ArgumentException($"Uncorrect currency coefficient: {nameof(coefficient)}");
            }
            if (dateOff == default)
            {
                dateOff = DateTime.MaxValue;
            }
            if (dateOn > dateOff)
            {
                throw new ArgumentException("Date off can't be earlier than Date on");
            }
            
            СurrencyCode = code;
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
            else
                dateOff = DateTime.MaxValue;
        }


    }    
}
