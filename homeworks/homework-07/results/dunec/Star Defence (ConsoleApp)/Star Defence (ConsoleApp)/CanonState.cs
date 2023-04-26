using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Defence__ConsoleApp_
{
    /// <summary>
    /// Состояния ПУШКИ
    /// </summary>
    internal enum CanonState
    {
        Awaiting,   // ожидание цели
        Aiming,        // прицеливание
        Atacking       // атака
    }
}
