namespace HomeWork_7
{
    /// <summary>
    /// Состояния ПУШКИ
    /// </summary>
    internal enum CanonState
    {
        Awaiting,  // ожидание цели
        Aim,        // прицеливание
        Atack    // атака
    }

    ///<summary>
    /// Cостояниt самолета
    /// </summary>
    internal enum PlaneState
    {
        TakeOff, // взлет
        Atack, // атака
        Refuel // дозаправка
    }

    /// <summary>
    /// Состояние танка
    /// </summary>
    internal enum TankState
    {
        Awaiting, // ожидание
        Moving, // движение
        Atack, // атака
        Defence  // защита
    }
}
