using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons.Accounts
{
    internal abstract class BankAccount : Owner, IAccountOperations
    {
        private string CashCurrencyCode { get; }
        internal BankAccount(string backID, string bankName, string ownersName, string ownersAdress, double cash = 0, double overdrive = 0)
        {
            _accountID = Guid.NewGuid().ToString();
            BankId = backID;
            BankName = bankName;
            OwnersAdress = ownersAdress;
            OwnersName = ownersName;
            amountOfCash = cash;
            CashCurrencyCode = "BYN";
        }

        protected readonly string _accountID;
        protected string blockReason = "";
        protected string BankId { get; }

        protected bool IsActive { get; set; }
        public string BankName { get; protected set; }

        public double amountOfCash;

        public void ActivateAccount()
        {
            IsActive = true;
        }

        public void AddFundToAccount(double incomeCash)
        {
            amountOfCash += incomeCash;
        }

        public void DeactivateAccount(string reason)
        {
            IsActive = false;
            blockReason = reason;
        }

        public abstract bool DeductFundFromAccount(double expenditure);

        public override string ToString()
        {
            string result = $"Status activity: {IsActive}\nAccount ID: {_accountID}\nBank Id: {BankId}\nBank's Name: {BankName}\nOwner's name: {OwnersName}\nOwner's address: {OwnersAdress}\nAmount of cash: {String.Format("{0:0.##}", amountOfCash)}";
            if (IsActive)
                return result;
            else
                return result.Insert(result.IndexOf("Account ID"), $"Block reason: {blockReason}\n");
        }
    }
}
