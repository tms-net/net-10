using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class EntityBankAccount : BankAccount
    {
        private readonly string _unp;

        private string TypeOfOrganization { get; }

        internal EntityBankAccount(string backID, string bankName, string organization, string ownersName, string ownersAdress, string unp, double cash = 0) : base(backID, bankName, ownersName, ownersAdress, cash)
        {
            if (unp.Length != 9 || Different_functions.IsDigitsOnly(unp))
                throw new ArgumentException("Uncorrect UNP");
            _unp = unp;
            TypeOfOrganization = organization;
        }

        public override string ToString()
        {
            string result = "";

            return result.Insert(result.IndexOf("Owner's name"), $"Entity's UNP: {_unp}\n"); ;
        }
    }
}
