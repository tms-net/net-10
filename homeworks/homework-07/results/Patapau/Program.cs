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
            unitStateManager.AllowTransition(CanonState.Aiming, CanonState.AwaitingTarget);
            try
            {
                unitStateManager.DeletePermissionTransition(CanonState.Aiming, CanonState.AwaitingTarget);
                Console.WriteLine(unitStateManager.Current);
                unitStateManager.MoveTo(CanonState.Aiming);
                Console.WriteLine(unitStateManager.Current);
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

