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
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        internal EntityBankAccount(string backID, string bankName, string organization, string ownersName, string ownersAdress, string unp, double cash = 0) : base(backID, bankName, ownersName, ownersAdress, cash)
        {
            if (unp.Length != 9 | IsDigitsOnly(unp))
                throw new ArgumentException("Uncorrect UNP");
            _unp = unp;
            TypeOfOrganization = organization;
        }       
    }
}
