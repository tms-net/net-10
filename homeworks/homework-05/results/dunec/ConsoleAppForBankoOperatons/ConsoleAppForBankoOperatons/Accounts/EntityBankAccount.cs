using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons.Accounts
{
    internal class EntityBankAccount : BankAccount
    {
        private readonly string _unp;

        private string TypeOfOrganization { get; }

        internal EntityBankAccount(string backID, string bankName, string organization, string ownersName, string ownersAdress, string unp, double cash = 0) : base(backID, bankName, ownersName, ownersAdress, cash)
        {
            if (unp.Length != 9 || !Helper.IsDigitsOnly(unp))
                throw new ArgumentException("Uncorrect UNP");
            _unp = unp;
            TypeOfOrganization = organization;
        }

        public override string ToString()
        {
            string result = base.ToString();

            return result.Insert(result.IndexOf("Owner's name"), $"Entity's UNP: {_unp}\n");
        }

        public override bool DeductFundFromAccount(double expenditure)
        {
            if (amountOfCash > expenditure)
            {
                amountOfCash -= expenditure;
                return true;
            }
            return false;
        }
    }
}
