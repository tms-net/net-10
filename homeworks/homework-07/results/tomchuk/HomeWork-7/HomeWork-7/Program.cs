using HomeWork_7;

var canonState = new UnitStateManager<CanonState>();
Console.WriteLine("CanonState :");

canonState.AllowTransition(CanonState.Awaiting, CanonState.Aim);
canonState.MoveTo(CanonState.Aim);
Console.WriteLine(canonState.Current.ToString());


canonState.AllowTransition(CanonState.Aim, CanonState.Atack);
canonState.MoveTo(CanonState.Atack);
Console.WriteLine(canonState.Current.ToString());


canonState.AllowTransition(CanonState.Atack, CanonState.Awaiting);
canonState.MoveTo(CanonState.Awaiting);
Console.WriteLine(canonState.Current.ToString());



var planeState = new UnitStateManager<PlaneState>();
Console.WriteLine("PlaneState :");

planeState.AllowTransition(PlaneState.TakeOff, PlaneState.Atack);
planeState.MoveTo(PlaneState.Atack);
Console.WriteLine(planeState.Current.ToString());

planeState.AllowTransition(PlaneState.Atack, PlaneState.Refuel);
planeState.MoveTo(PlaneState.Refuel);
Console.WriteLine(planeState.Current.ToString());

planeState.AllowTransition(PlaneState.Refuel, PlaneState.TakeOff);
planeState.MoveTo(PlaneState.TakeOff);
Console.WriteLine(planeState.Current.ToString());

var tankState = new UnitStateManager<TankState>();
Console.WriteLine("TankState :");

tankState.AllowTransition(TankState.Awaiting, TankState.Moving);
tankState.MoveTo(TankState.Moving);
Console.WriteLine(tankState.Current.ToString());


tankState.AllowTransition(TankState.Moving, TankState.Atack);
tankState.MoveTo(TankState.Atack);
Console.WriteLine(tankState.Current.ToString());


tankState.AllowTransition(TankState.Atack, TankState.Defence);
tankState.MoveTo(TankState.Defence);
Console.WriteLine(tankState.Current.ToString());


tankState.AllowTransition(TankState.Defence, TankState.Awaiting);
tankState.MoveTo(TankState.Awaiting);
Console.WriteLine(tankState.Current.ToString());

