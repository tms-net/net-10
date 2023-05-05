using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class PersonalBankAccount : BankAccount
    {
        private readonly string _id;

        internal PersonalBankAccount(string backID, string bankName, string ownersName, string ownersAdress, string id, double cash = 0, double overdrive = 0): base(backID, bankName, ownersName, ownersAdress, cash, overdrive) 
        {
            if (id.Length != 14)
                throw new ArgumentException("Uncorrect personal №");
            _id = id;
        }
    }
}
