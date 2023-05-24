using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patapau
{
    /// <summary>
    /// Состояния героя
    /// </summary>
    internal enum HeroesState
    {
        Expectation,//ожидание
        Movement,//движение     
        Attack,//атака
        Protection//защита     
    }
    /// <summary>
    /// Состояния самолета
    /// </summary>
    internal enum FlyState
    {
        Takeoff,//взлет
        Attack,//атака     
        Refueling//дозаправка
    }

    /// <summary>
    /// Состояния ПУШКИ
    /// </summary>
    internal enum CanonState
    {
        AwaitingTarget, //ожидание цели
        Aiming, // прицеливание
        Attack // атака
    }

}
