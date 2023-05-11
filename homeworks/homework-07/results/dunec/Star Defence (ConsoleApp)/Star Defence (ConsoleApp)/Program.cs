using Star_Defence__ConsoleApp_;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            canon.AllowTransition(CanonState.Awaiting, CanonState.Aiming);
            canon.AllowTransition(CanonState.Aiming, CanonState.Atacking);
            canon.AllowTransition(CanonState.Atacking, CanonState.Awaiting);

            starship.AllowTransition(StarshipState.Takeoff, StarshipState.Attacking);
            starship.AllowTransition(StarshipState.Attacking, StarshipState.Land);
            starship.AllowTransition(StarshipState.Land, StarshipState.Takeoff);

            tank.AllowTransition(TankState.Awaiting, TankState.Moving);
            tank.AllowTransition(TankState.Moving, TankState.Attaking);
            tank.AllowTransition(TankState.Attaking, TankState.Defending);
            tank.AllowTransition(TankState.Attaking, TankState.Awaiting);
            tank.AllowTransition(TankState.Defending, TankState.Awaiting);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }

        Random rand = new Random();
        Console.WriteLine($"Cannon's deafult status is {canon.Current}");
        Console.WriteLine($"Starship's deafult status is {starship.Current}");
        Console.WriteLine($"Tank's deafult status is {tank.Current}");
        Console.WriteLine("");
        for (int i = 0; i < 100; i++)
        {
            string UnitName = "";
            try
            {               
                switch (rand.Next(3))
                {
                    case 0: 
                        {
                            UnitName = "Canon: ";
                            canon.MoveTo((CanonState)rand.Next(2));
                            PrintAction(UnitName, canon.Current);
                        } break; 
                    case 1: 
                        {
                            UnitName = "Starship: ";
                            starship.MoveTo((StarshipState)rand.Next(2));
                            PrintAction(UnitName, starship.Current);
                        } break; 
                    case 2: 
                        {
                            UnitName = "Tank: ";
                            tank.MoveTo((TankState)rand.Next(3));
                            PrintAction(UnitName, tank.Current);
                        } break; 
                    default: 
                        { 
                        } break;
                }               
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(UnitName + e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(UnitName + e.Message);
            }                     
        }

        Console.ReadLine();
    }

    internal static void PrintAction(string unitName, Enum state)
    {
        string field = "-------------------------------------------------------------------";
        Console.WriteLine($"{field}\n{unitName}status was successfully changed to {state}\n{field}");
    }


}