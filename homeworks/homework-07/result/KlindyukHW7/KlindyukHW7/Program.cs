// See https://aka.ms/new-console-template for more information
using KlindyukHW7;

var shootingStates = new UnitStateManager<ShootingState>(ShootingState.Awaiting);
shootingStates.AllowTransition
    (
    (ShootingState.Awaiting, ShootingState.Aim),
    (ShootingState.Aim, ShootingState.Atack),
    (ShootingState.Atack, ShootingState.Awaiting)
    );
Console.WriteLine($"{shootingStates.Current} to {ShootingState.Aim} ->" +
    $" {shootingStates.MoveTo(ShootingState.Aim)}"); //true

Console.WriteLine($"{shootingStates.Current} to {ShootingState.Atack} -> " +
    $"{shootingStates.MoveTo(ShootingState.Atack)}"); //true

Console.WriteLine($"{shootingStates.Current} to {ShootingState.Awaiting} -> " +
    $"{shootingStates.MoveTo(ShootingState.Awaiting)}"); //true

Console.WriteLine($"{shootingStates.Current} to {ShootingState.Atack} -> " +
    $"{shootingStates.MoveTo(ShootingState.Atack)}\n"); //false

//-------------------------------------------------------------------------------------

var destroyerStates = new UnitStateManager<DestroyerState>(DestroyerState.LiftOff);
destroyerStates.AllowTransition
    (
    (DestroyerState.LiftOff, DestroyerState.Atack),
    (DestroyerState.Atack, DestroyerState.Refilling),
    (DestroyerState.Refilling, DestroyerState.LiftOff)
    );
Console.WriteLine($"{destroyerStates.Current} to {DestroyerState.Atack} ->" +
    $" {destroyerStates.MoveTo(DestroyerState.Atack)}"); //true

Console.WriteLine($"{destroyerStates.Current} to {DestroyerState.Refilling} -> " +
    $"{destroyerStates.MoveTo(DestroyerState.Refilling)}"); //true

Console.WriteLine($"{destroyerStates.Current} to {DestroyerState.LiftOff} -> " +
    $"{destroyerStates.MoveTo(DestroyerState.LiftOff)}\n"); //true

//-------------------------------------------------------------------------------------

var troopersStates = new UnitStateManager<TroopersState>(TroopersState.Awaiting);
troopersStates.AllowTransition
    (
    (TroopersState.Awaiting, TroopersState.Move),
    (TroopersState.Move, TroopersState.Atack),
    (TroopersState.Atack, TroopersState.Defense),
    (TroopersState.Defense, TroopersState.Awaiting),
    (TroopersState.Atack, TroopersState.Awaiting)
    );
Console.WriteLine($"{troopersStates.Current} to {TroopersState.Move} ->" +
    $" {troopersStates.MoveTo(TroopersState.Move)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Atack} -> " +
    $"{troopersStates.MoveTo(TroopersState.Atack)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Defense} -> " +
    $"{troopersStates.MoveTo(TroopersState.Defense)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Awaiting} -> " +
    $"{troopersStates.MoveTo(TroopersState.Awaiting)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Move} ->" +
    $" {troopersStates.MoveTo(TroopersState.Move)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Atack} -> " +
    $"{troopersStates.MoveTo(TroopersState.Atack)}"); //true

Console.WriteLine($"{troopersStates.Current} to {TroopersState.Awaiting} -> " +
    $"{troopersStates.MoveTo(TroopersState.Awaiting)}"); //true

