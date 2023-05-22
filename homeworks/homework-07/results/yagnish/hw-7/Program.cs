using System.Linq.Expressions;

namespace hw_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var CannonStateTransisions = new (CanonState, CanonState)[] {(CanonState.AwaitingTarget,CanonState.Aiming),
                                                                              (CanonState.Aiming, CanonState.Atack),
                                                                              (CanonState.Atack, CanonState.AwaitingTarget) };
            var DestroyerStateTransisions = new (DestroyerState, DestroyerState)[] {(DestroyerState.LiftOff,DestroyerState.Atack),
                                                                              (DestroyerState.Atack, DestroyerState.Landing),
                                                                              (DestroyerState.Landing, DestroyerState.LiftOff)};
            var TankStateTransisions = new (TankState, TankState)[] { (TankState.Awaiting, TankState.Moving), (TankState.Moving, TankState.Atack), (TankState.Atack, TankState.Defence), (TankState.Defence, TankState.Awaiting), (TankState.Atack, TankState.Awaiting)  };
            var TankStateManager = new UniteStateManager<TankState>(TankStateTransisions,TankState.Awaiting);
            var DestroyerStateManager = new UniteStateManager<DestroyerState>(DestroyerStateTransisions,DestroyerState.LiftOff);
            var CanonStateManager = new UniteStateManager<CanonState>(CannonStateTransisions,CanonState.AwaitingTarget);
            
            var UnitChosen = Console.ReadLine();
            Console.WriteLine(@"Choose your entity: 
1.Canon
2.Destroyer
3.Tank.");
            while (true) 
            {
                switch (UnitChosen)
                {
                    case "1":
                        Console.WriteLine(@"Choose next state: 
1.Awaiting
2.Aiming
3.Atack.");
                        CanonStateManager.MoveTo((CanonState)Int32.Parse(Console.ReadLine()));
                        Console.WriteLine($"Current state:{CanonStateManager._current}");
                        break;
                    case "2":
                        Console.WriteLine(@"Choose next state: 
1.LiftOff
2.Atack
3.Landing.");
                        DestroyerStateManager.MoveTo((DestroyerState)Int32.Parse(Console.ReadLine()));
                        Console.WriteLine($"Current state:{DestroyerStateManager._current}");
                        break;
                    case "3":
                        Console.WriteLine(@"Choose next state: 
1.Awaiting
2.Moving
3.Atack
4.Defence");
                        TankStateManager.MoveTo((TankState)Int32.Parse(Console.ReadLine()));
                        Console.WriteLine($"Current state:{TankStateManager._current}");
                        break;
                }

            }
        }
    }
}