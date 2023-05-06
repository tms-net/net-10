using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal abstract class BankAccount : Owner, IAccountOperations
    {
        internal BankAccount(string backID, string bankName, string ownersName, string ownersAdress, double cash = 0, double overdrive = 0)
        {
            _accountID = Guid.NewGuid().ToString();
            BankId = backID;
            BankName = bankName;
            OwnersAdress = ownersAdress;
            OwnersName = ownersName;
            amountOfCash = cash;
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

        public bool AddFundToAccount(double incomeCash)
        {
            if (IsActive)
            {
                amountOfCash += incomeCash;
                return true;
            }
            else
            { 
                return false; 
            }               
        }

        public void DeactivateAccount(string reason)
        {
            IsActive = false;
            blockReason = reason;
        }

        public virtual bool DeductFundFromAccount(double expenditure)
        {
            if (amountOfCash > expenditure)
            {
                amountOfCash -= expenditure;
                return true;
            }
            return false;           
        }

        public override string ToString()
        {
            string result = $"Status: {IsActive}\nAccount ID: {_accountID}\nBank Id: {BankId}\nBank's Name: {BankName}\nOwner's name: {OwnersName}\nOwner's address: {OwnersAdress}\nAmount of cash: {amountOfCash}";
            if (IsActive)
                return result;
            else
                return result.Insert(result.IndexOf("Account ID"), $"Block reason: {blockReason}\n");
        }
    }
}
