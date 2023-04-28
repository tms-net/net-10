// See https://aka.ms/new-console-template for more information
using StarDefence;
using StarDefenceUnits;



var disp = new DisposableClass();

Console.WriteLine("Hello, World!");

var canonState = CanonState.AwaitingTarget;

var intValue = (int)canonState;

canonState = (CanonState)intValue;

// canon

// state machine (конечный автомат, машина состояний)

// canon -> state machine

var canonStateManager = new UnitStateManager<CanonState>(
    //new[] { CanonState.AwaitingTarget /*0*/, CanonState.Aiming /*1*/ },
    //new[] { CanonState.Aiming /*0*/, CanonState.Atack /*1*/ },
    //new[] { CanonState.Atack, CanonState.AwaitingTarget });

    //new Tuple<CanonState, CanonState>(CanonState.AwaitingTarget /*0*/, CanonState.Aiming /*1*/),
    //new Tuple<CanonState, CanonState>(CanonState.Aiming /*0*/, CanonState.Atack /*1*/),
    //new Tuple<CanonState, CanonState>(CanonState.Atack, CanonState.AwaitingTarget ));

//new []
//{
//    new [] { CanonState.AwaitingTarget /*0*/, CanonState.Aiming /*1*/ },
//    new [] { CanonState.Aiming /*0*/, CanonState.Atack /*1*/ },
//    new [] {CanonState.Atack, CanonState.AwaitingTarget }
//} 

    (from: CanonState.AwaitingTarget /*0*/, CanonState.Aiming /*1*/), //0
    (CanonState.Aiming /*0*/, to: CanonState.Atack /*1*/), // 1
    (CanonState.Aiming /*0*/, CanonState.AwaitingTarget /*1*/), //2
    (CanonState.Atack /*0*/, CanonState.AwaitingTarget /*1*/) // 3
    );

// destroyer -> state machine

var destroyerManager = new UnitStateManager<DestroyerState>();

// tank -> state machine

// получить команду -> нужное состояние

canonStateManager.MoveTo(CanonState.Atack);

