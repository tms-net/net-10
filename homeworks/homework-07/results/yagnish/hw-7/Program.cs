namespace hw_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var CannonStateTransisions = new Tuple<CanonState, CanonState>[] {Tuple.Create(CanonState.AwaitingTarget,CanonState.Aiming),
                                                                              Tuple.Create(CanonState.Aiming, CanonState.Atack),
                                                                              Tuple.Create(CanonState.Atack, CanonState.AwaitingTarget) };
            var DestroyerStateTransisions = new Tuple<DestroyerState, DestroyerState>[] {Tuple.Create(DestroyerState.LiftOff,DestroyerState.Atack),
                                                                              Tuple.Create(DestroyerState.Atack,DestroyerState.Landing),
                                                                              Tuple.Create(DestroyerState.Landing,DestroyerState.LiftOff)};
            var TankStateTransisions = new Tuple<TankState, TankState>[] {Tuple.Create(TankState.Awaiting,TankState.Moving),
                                                                          Tuple.Create(TankState.Moving,TankState.Atack)
                                                                          Tuple.Create(TankState.Awaiting,TankState.Moving)}
        }
    }
}