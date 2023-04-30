// See https://aka.ms/new-console-template for more information
using KlindyukHW7;

var shootingStates = new UnitStateManager<ShootingState>();

shootingStates.AllowTransition(ShootingState.Awaiting, ShootingState.Aim);
Console.Write($"{shootingStates.Current} to {ShootingState.Aim} -> "); //Сurrent = Awaiting
shootingStates.MoveTo(ShootingState.Aim);
Console.WriteLine($"{shootingStates.Current}"); //Сurrent = Aim

shootingStates.AllowTransition(ShootingState.Aim, ShootingState.Atack);
Console.Write($"{shootingStates.Current} to {ShootingState.Atack} -> "); //Сurrent = Aim
shootingStates.MoveTo(ShootingState.Atack);
Console.WriteLine($"{shootingStates.Current}"); //Сurrent = Atack

shootingStates.AllowTransition(ShootingState.Atack, ShootingState.Awaiting);
Console.Write($"{shootingStates.Current} to {ShootingState.Awaiting} -> "); //Сurrent = Atack
shootingStates.MoveTo(ShootingState.Awaiting);
Console.WriteLine($"{shootingStates.Current}\n"); //Сurrent = Awaiting


var destroyerStates = new UnitStateManager<DestroyerState>();

destroyerStates.AllowTransition(DestroyerState.LiftOff, DestroyerState.Atack);
Console.Write($"{destroyerStates.Current} to {DestroyerState.Atack} -> "); //Сurrent = LiftOff
destroyerStates.MoveTo(DestroyerState.Atack);
Console.WriteLine($"{destroyerStates.Current}"); //Сurrent = Atack

destroyerStates.AllowTransition(DestroyerState.Atack, DestroyerState.Refilling);
Console.Write($"{destroyerStates.Current} to {DestroyerState.Refilling} -> "); //Сurrent = Atack
destroyerStates.MoveTo(DestroyerState.Refilling);
Console.WriteLine($"{destroyerStates.Current}"); //Сurrent = Refilling

destroyerStates.AllowTransition(DestroyerState.Refilling, DestroyerState.LiftOff);
Console.Write($"{destroyerStates.Current} to {DestroyerState.LiftOff} -> "); //Сurrent = Refilling
destroyerStates.MoveTo(DestroyerState.LiftOff);
Console.WriteLine($"{destroyerStates.Current}\n"); //Сurrent = LiftOff


var troopersState = new UnitStateManager<TroopersState>();

troopersState.AllowTransition(TroopersState.Awaiting, TroopersState.Move);
Console.Write($"{troopersState.Current} to {TroopersState.Move} -> "); //Сurrent = Awaiting
troopersState.MoveTo(TroopersState.Move);
Console.WriteLine($"{troopersState.Current}"); //Сurrent = Move

troopersState.AllowTransition(TroopersState.Move, TroopersState.Atack);
Console.Write($"{troopersState.Current} to {TroopersState.Atack} -> "); //Сurrent = Move
troopersState.MoveTo(TroopersState.Atack);
Console.WriteLine($"{troopersState.Current}"); //Сurrent = Atack

troopersState.AllowTransition(TroopersState.Atack, TroopersState.Defense);
Console.Write($"{troopersState.Current} to {TroopersState.Defense} -> "); //Сurrent = Atack
troopersState.MoveTo(TroopersState.Defense);
Console.WriteLine($"{troopersState.Current}"); //Сurrent = Defense

troopersState.AllowTransition(TroopersState.Defense, TroopersState.Awaiting);
Console.Write($"{troopersState.Current} to {TroopersState.Awaiting} -> "); //Сurrent = Defense
troopersState.MoveTo(TroopersState.Awaiting);
Console.WriteLine($"{troopersState.Current}"); //Сurrent = Awaiting

troopersState.MoveTo(TroopersState.Move);
troopersState.MoveTo(TroopersState.Atack);
troopersState.AllowTransition(TroopersState.Atack, TroopersState.Awaiting);
Console.Write($"{troopersState.Current} to {TroopersState.Awaiting} -> "); //Сurrent = Atack
troopersState.MoveTo(TroopersState.Awaiting);
Console.WriteLine($"{troopersState.Current}"); //Сurrent = Awaiting


