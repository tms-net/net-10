using Homework_7;

//first task
var canonStateManager = new UnitStateManager<CanonState>(CanonState.Awaiting);
canonStateManager.AddAllowedStateTransition
    (
    (CanonState.Awaiting, CanonState.Aim),
    (CanonState.Aim, CanonState.Atack),
    (CanonState.Atack, CanonState.Awaiting)
    );
Console.WriteLine("Canon transition:");
Console.WriteLine($"{canonStateManager.CurrentState} to {CanonState.Aim} -> {canonStateManager.MoveToState(CanonState.Aim)}"); //true
Console.WriteLine($"{canonStateManager.CurrentState} to {CanonState.Atack} -> {canonStateManager.MoveToState(CanonState.Atack)}"); //true
Console.WriteLine($"{canonStateManager.CurrentState} to {CanonState.Awaiting} -> {canonStateManager.MoveToState(CanonState.Awaiting)}"); //true
Console.WriteLine($"{canonStateManager.CurrentState} to {CanonState.Atack} -> {canonStateManager.MoveToState(CanonState.Atack)}"); //false


//second task
var planeStateManager = new UnitStateManager<PlaneState>(PlaneState.TakeOff);
planeStateManager.AddAllowedStateTransition
    (
    (PlaneState.TakeOff, PlaneState.Atack),
    (PlaneState.Atack, PlaneState.Land),
    (PlaneState.Land, PlaneState.TakeOff)
    );
Console.WriteLine("\nPlane transition:");
Console.WriteLine($"{planeStateManager.CurrentState} to {PlaneState.Atack} -> {planeStateManager.MoveToState(PlaneState.Atack)}");
Console.WriteLine($"{planeStateManager.CurrentState} to {PlaneState.Land} -> {planeStateManager.MoveToState(PlaneState.Land)}");
Console.WriteLine($"{planeStateManager.CurrentState} to {PlaneState.TakeOff} -> {planeStateManager.MoveToState(PlaneState.TakeOff)}");
Console.WriteLine($"{planeStateManager.CurrentState} to {PlaneState.Land} -> {planeStateManager.MoveToState(PlaneState.Land)}");


//third task
var fighterPlane = new UnitStateManager<FighterState>(FighterState.Awaiting);
fighterPlane.AddAllowedStateTransition
    (
    (FighterState.Awaiting, FighterState.Moving),
    (FighterState.Moving, FighterState.Atack),
    (FighterState.Atack, FighterState.Awaiting),
    (FighterState.Atack, FighterState.Protect),
    (FighterState.Protect, FighterState.Awaiting)
    );
Console.WriteLine("\nFighter plane transition:");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Moving} -> {fighterPlane.MoveToState(FighterState.Moving)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Atack} -> {fighterPlane.MoveToState(FighterState.Atack)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Awaiting} -> {fighterPlane.MoveToState(FighterState.Awaiting)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Moving} -> {fighterPlane.MoveToState(FighterState.Moving)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Atack} -> {fighterPlane.MoveToState(FighterState.Atack)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Protect} -> {fighterPlane.MoveToState(FighterState.Protect)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Awaiting} -> {fighterPlane.MoveToState(FighterState.Awaiting)}");
Console.WriteLine($"{fighterPlane.CurrentState} to {FighterState.Protect} -> {fighterPlane.MoveToState(FighterState.Protect)}");


