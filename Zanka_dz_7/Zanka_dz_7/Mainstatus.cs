using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanka_dz_7
{
    class Mainstatus
    {
        /// <summary>
        /// Cтатус основного юзера 
        /// </summary>
        internal enum Status
        {
            StartFlying, //взлёт
            Flying, //полёт
            Attack, //атака
            EndFlying,//приземление
            Refueling,  //заправка
        }
    }
}
