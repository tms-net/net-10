using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7Lutynski
{

    public enum CanonState
    {
        Await,
        Aim,
        Shoot
    }
    public enum DestroyerState
    {
        Await,
        Takeoff,
        Aim,
        Shoot,
        Land
    }
    public enum TankState
    {
        Await,
        Aim,
        Shoot,
        Move
    }

}
