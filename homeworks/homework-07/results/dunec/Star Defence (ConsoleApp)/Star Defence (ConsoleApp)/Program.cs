using Star_Defence__ConsoleApp_;
using System.Net.Http.Headers;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Initializing 3 types of the acceptable game units");

        var canon = new UnitStateManager<CanonState>();
        var starship = new UnitStateManager<StarshipState>();
        var tank = new UnitStateManager<TankState>();
        try
        {
            tank.AllowTransition(TankState.Attaking, TankState.Awaiting);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }

        Random rand = new Random();
        Console.WriteLine($"Cannon's deafult status is {canon.Current}");
        for (int i = 0; i < 15; i++)
        {
            try
            {
                canon.MoveTo((CanonState)rand.Next(3));
                Console.WriteLine($"Cannon's status was successfully changed to {canon.Current}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }                     
        }
        Console.WriteLine($"\nStarship's deafult status is {starship.Current}");
        for (int i = 0; i < 15; i++)
        {
            try
            {
                starship.MoveTo((StarshipState)rand.Next(3));
                Console.WriteLine($"Starship's status was successfully changed to {starship.Current}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Console.WriteLine($"\nTank's deafult status is {tank.Current}");
        for (int i = 0; i < 15; i++)
        {
            try
            {
                tank.MoveTo((TankState)rand.Next(4));
                Console.WriteLine($"Tank's status was successfully changed to {tank.Current}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.ReadLine();
    }

}