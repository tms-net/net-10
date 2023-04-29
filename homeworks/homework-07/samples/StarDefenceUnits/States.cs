namespace StarDefenceUnits
{
    /// <summary>
    /// Состояния ПУШКИ
    /// </summary>
    [Flags]
    public enum CanonState : int
    {
        AwaitingTarget = 0b0001, //ожидание цели
        Aiming = 0b0010, // прицеливание
        Atack = 0b0100 // атака
    }

    // 0 0 1 0
    // 0 0 0 1
    //    OR
    // 0 0 1 1

    /// <summary>
    /// Состояния Истребителя
    /// </summary>
    public enum DestroyerState : int
    {
        LiftOff = 1,
        Atack = 2,
        Landing = 4
    }
}