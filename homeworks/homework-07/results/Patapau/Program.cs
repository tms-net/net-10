namespace Patapau
{
    internal class Program
    {

        static void Main(string[] args)
        {
            UnitStateManager<CanonState> unitStateManager = new UnitStateManager<CanonState>(
                (CanonState.AwaitingTarget, CanonState.Aiming),
                (CanonState.Aiming, CanonState.Attack),
                (CanonState.Attack, CanonState.AwaitingTarget));
            UnitStateManager<FlyState> unitStateManagerFly = new UnitStateManager<FlyState>(
                (FlyState.Takeoff, FlyState.Attack),
                (FlyState.Attack, FlyState.Refueling),
                (FlyState.Refueling, FlyState.Takeoff));
            UnitStateManager<HeroesState> unitStateManagerHeroes = new UnitStateManager<HeroesState>(
               (HeroesState.Expectation, HeroesState.Movement),
               (HeroesState.Movement, HeroesState.Attack),
               (HeroesState.Attack, HeroesState.Expectation),
               (HeroesState.Attack, HeroesState.Protection),
               (HeroesState.Protection, HeroesState.Expectation)
               );
            try
            {
                unitStateManager.MoveTo(CanonState.Aiming);
                unitStateManager.MoveTo(CanonState.Attack);
                unitStateManager.MoveTo(CanonState.AwaitingTarget);

                unitStateManagerFly.MoveTo(FlyState.Attack);
                unitStateManagerFly.MoveTo(FlyState.Refueling);
                unitStateManagerFly.MoveTo(FlyState.Takeoff);

                unitStateManagerHeroes.MoveTo(HeroesState.Movement);
                unitStateManagerHeroes.MoveTo(HeroesState.Attack);
                unitStateManagerHeroes.MoveTo(HeroesState.Expectation);
                unitStateManagerHeroes.MoveTo(HeroesState.Movement);
                unitStateManagerHeroes.MoveTo(HeroesState.Attack);
                unitStateManagerHeroes.MoveTo(HeroesState.Protection);
                unitStateManagerHeroes.MoveTo(HeroesState.Expectation);


            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }

}

