using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons.Accounts
{
    internal interface IAccountOperations
    {
        void ActivateAccount();
        void DeactivateAccount(string blockReason);
        void AddFundToAccount(double incomeCash);
        bool DeductFundFromAccount(double expenditure);

    }
}
