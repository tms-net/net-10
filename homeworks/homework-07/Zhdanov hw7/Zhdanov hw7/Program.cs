using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhdanov_hw7;

internal class Program
{
    static void Main(string[] args)
    {
        var planeStates = new UnitStateManager<PlaneState>();
        
        Random random = new Random();
        int a = random.Next();

        try

        {
            if (a % 2 == 0)
            {
                planeStates.Transition(PlaneState.TakeOff, PlaneState.Land);
                Console.WriteLine($"{planeStates.Current} to {PlaneState.Land}");
                planeStates.Moveto(PlaneState.Land);
                Console.WriteLine("Полёт прошел без происшествий");

                planeStates.Transition(PlaneState.Land, PlaneState.Refuel);
                planeStates.Moveto(PlaneState.Refuel);

                planeStates.Transition(PlaneState.Refuel, PlaneState.TakeOff);
                planeStates.Moveto(PlaneState.TakeOff);
            }

            else
            {
                planeStates.Transition(PlaneState.TakeOff, PlaneState.Crash);
                Console.WriteLine($"{planeStates.Current} to {PlaneState.Crash}");
                planeStates.Moveto(PlaneState.Crash);
                Console.WriteLine("Самолет потерпел крушение");

            }
        }
        catch
        {
            throw new Exception("Error");
        }
    
       
        //____________________________________________________________

        var canonStates = new UnitStateManager<CanonState>();

        canonStates.Transition(CanonState.Awaiting, CanonState.Aim);
        canonStates.Moveto(CanonState.Aim);

        canonStates.Transition(CanonState.Aim, CanonState.Atack);
        canonStates.Moveto(CanonState.Atack);

        canonStates.Transition(CanonState.Atack, CanonState.Awaiting);
        canonStates.Moveto(CanonState.Awaiting);

        //_____________________________________________________________

        var tankStates = new UnitStateManager<TankState>();

        tankStates.Transition(TankState.Awaiting, TankState.Moving);
        tankStates.Moveto(TankState.Moving);

        tankStates.Transition(TankState.Moving, TankState.Atack);
        tankStates.Moveto(TankState.Atack);

        tankStates.Transition(TankState.Atack, TankState.Defence);
        tankStates.Moveto(TankState.Defence);
        tankStates.Transition(TankState.Atack, TankState.Awaiting);

        tankStates.Transition(TankState.Defence, TankState.Awaiting);
        tankStates.Moveto(TankState.Awaiting);

        


    }
}
