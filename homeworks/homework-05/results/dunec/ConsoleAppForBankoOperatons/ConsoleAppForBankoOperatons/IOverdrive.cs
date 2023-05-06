using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForBankoOperatons
{
    internal interface IOverdrive
    {
        bool IsCreditAccount();
        bool AddOverdrive(double overdrive);
        void TakeOffOverdrive();
    }
}
