using HW7Lutynski;
using System;

UnitStateManager<TankState> Tank = new UnitStateManager<TankState>();
UnitStateManager<DestroyerState> destroyer = new UnitStateManager<DestroyerState>();
UnitStateManager<CanonState> canon = new UnitStateManager<CanonState>();

Console.WriteLine(Tank.Current);
Tank.AllowTransition(TankState.Await, TankState.Aim);
Tank.AllowTransition(TankState.Aim, TankState.Shoot);
Tank.AllowTransition(TankState.Shoot, TankState.Aim);
Tank.AllowTransition(TankState.Shoot, TankState.Await);
Tank.AllowTransition(TankState.Await, TankState.Move);

canon.AllowTransition(CanonState.Await, CanonState.Aim);
canon.AllowTransition(CanonState.Aim, CanonState.Shoot);
canon.AllowTransition(CanonState.Shoot, CanonState.Await);
canon.AllowTransition(CanonState.Shoot, CanonState.Aim);

destroyer.AllowTransition(DestroyerState.Await, DestroyerState.Takeoff);
destroyer.AllowTransition(DestroyerState.Takeoff, DestroyerState.Aim);
destroyer.AllowTransition(DestroyerState.Aim, DestroyerState.Shoot);
destroyer.AllowTransition(DestroyerState.Shoot, DestroyerState.Land);
destroyer.AllowTransition(DestroyerState.Land, DestroyerState.Await);


Tank.MoveTo(TankState.Aim);
//Tank.MoveTo(TankState.Await); //InvalidOperationException
Tank.MoveTo(TankState.Shoot);
canon.MoveTo(CanonState.Aim);
canon.MoveTo(CanonState.Shoot);
destroyer.MoveTo(DestroyerState.Takeoff);
destroyer.MoveTo(DestroyerState.Aim);
destroyer.MoveTo(DestroyerState.Shoot);
