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
        private readonly string _accountID;
        private bool IsActive { get; set; }

        private string blockReason = "";
        private string BankId { get; }

        internal BankAccount(string backID, string bankName, string ownersName, string ownersAdress, double cash = 0, double overdrive = 0)
        {
            _accountID = Guid.NewGuid().ToString();
            BankId = backID;
            BankName = bankName;
            OwnersAdress = ownersAdress;
            OwnersName = ownersName;
            amountOfCash = cash;
            Overdrive = overdrive;
        }
                    
        public string BankName { get; protected set; }

        public double Overdrive { get; set; }

        public double amountOfCash;

        public bool IsCreditAccount()
        { 
            if (Overdrive > 0) 
                return true;
            else
                return false;
        }

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

        public bool DeductFundFromAccount(double expenditure)
        {
            double fullAmount = amountOfCash;
            if (IsActive)
            {
                if (IsCreditAccount())
                {
                    fullAmount += Overdrive;
                }

                if (fullAmount > expenditure)
                { 
                    amountOfCash -= expenditure;
                    return true;
                }
                else
                    return false;
            }
            else
                return false; 
        }        
    }
}
