using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal class PersonalBankAccount : BankAccount, IOverdrive
    {
        private readonly string _id;

        public double Overdrive { get; set; }

        internal PersonalBankAccount(string backID, string bankName, string ownersName, string ownersAdress, string id, double cash = 0, double overdrive = 0) : base(backID, bankName, ownersName, ownersAdress, cash)
        {
            if (id.Length != 14)
                throw new ArgumentException("Uncorrect personal №");
            _id = id;
            Overdrive = overdrive;
        }
        public bool IsCreditAccount()
        {
            if (Overdrive > 0)
                return true;
            else
                return false;
        }
        public override bool DeductFundFromAccount(double expenditure)
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

        public bool AddOverdrive(double overdrive)
        {
            if (Overdrive == 0)
            {
                Overdrive = overdrive;
                return true;
            }
            else
                return false;
        }

        public void TakeOffOverdrive()
        {
            if (IsCreditAccount())
            { 
                Overdrive = 0;
                if (amountOfCash < 0 )
                {
                    DeactivateAccount("Negative balance");
                }
            }
        }

        public override string ToString()
        {
            string result = "";

            if (IsCreditAccount()) 
                result = base.ToString() + $"\nOverdrive: true\nAmount of overdrive: {Overdrive}";
            else
                result = base.ToString() + $"\nOverdrive: false";

            return result.Insert(result.IndexOf("Owner's name"), $"Owner's id: {_id}\n");
        }
    }
}
