using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw7
{
 
     ///<summary>
     /// Cостояниt самолета
     /// </summary>
     
    internal enum PlaneState
    {
        TakeOff,
        Land,
        Crash,
        Refuel
    }

    ///<summary>
    /// Состояния пушки
    ///</summary>
    internal enum CanonState
    {
        Awaiting,
        Aim,
        Atack        
    }
    internal enum TankState
    {
        Awaiting,
        Moving,
        Atack,
        Defence
    }
}  
