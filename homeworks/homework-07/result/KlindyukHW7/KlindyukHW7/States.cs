using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW7
{
    /// <summary>
    /// Состояние пушки
    /// </summary>
    internal enum ShootingState
    {
        Awaiting, //ожидание цели
        Aim,      //прицеливание 
        Atack     //атака
    }

    /// <summary>
    /// Состояние истребителя
    /// </summary>
    internal enum DestroyerState
    {
        LiftOff,   //взлет
        Atack,     //атака
        Refilling  //дозаправка
    }

    /// <summary>
    /// Состояние кавалерии
    /// </summary>
    internal enum TroopersState
    {
        Awaiting,  //ожидание цели
        Move,      //прицеливание 
        Atack,     //атака
        Defense    //защита
    }
}
