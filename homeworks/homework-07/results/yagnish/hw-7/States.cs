using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_7
{
    [Flags]
    /// <summary>
    /// Состояния пушки
    /// </summary>
    public enum CanonState : int
    {
        AwaitingTarget = 1, 
        Aiming = 2, 
        Atack = 4 
    }


    /// <summary>
    /// Состояния истребителя
    /// </summary>
    public enum DestroyerState : int
    {
        LiftOff = 1,
        Atack = 2,
        Landing = 4
    }

    /// <summary>
    /// Состояния танка
    /// </summary>
    public enum TankState : int
    {
        Awaiting = 1,
        Moving = 2,
        Atack = 4,
        Defence = 8
    }
}
